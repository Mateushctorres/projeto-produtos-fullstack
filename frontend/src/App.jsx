import { useState, useEffect } from 'react';
import ProductList from './components/ProductList';
import ProductForm from './components/ProductForm';
import api from './services/api';
import './index.css';

import { Container, Typography } from '@mui/material';

function App() {
  const [products, setProducts] = useState([]);
  const [editingProduct, setEditingProduct] = useState(null);

  useEffect(() => {
    async function fetchProducts() {
      try {
        const response = await api.get('/produtos');
        setProducts(response.data);
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
      }
    }
    fetchProducts();
  }, []);

  const handleProductCreated = (newProduct) => {
    setProducts(currentProducts => [...currentProducts, newProduct]);
  };

  const handleDeleteProduct = async (productId) => {
    try {
      await api.delete(`/produtos/${productId}`);
      setProducts(currentProducts => currentProducts.filter(product => product.id !== productId));
    } catch (error) {
      console.error("Erro ao deletar produto:", error);
      alert("Falha ao deletar o produto!");
    }
  };

  const handleEditProduct = (product) => {
    setEditingProduct(product);
  };

  const handleCancelEdit = () => {
    setEditingProduct(null);
  };

  const handleProductUpdated = (updatedProduct) => {
    setProducts(currentProducts => 
      currentProducts.map(p => (p.id === updatedProduct.id ? updatedProduct : p))
    );
    setEditingProduct(null);
  };

  return (
    <Container maxWidth="lg" sx={{ marginTop: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Gestão de Produtos
      </Typography>
      <ProductForm 
        onProductCreated={handleProductCreated}
        productToEdit={editingProduct}
        onProductUpdated={handleProductUpdated}
        onCancelEdit={handleCancelEdit}
      />
      <ProductList 
        products={products} 
        onDelete={handleDeleteProduct}
        onEdit={handleEditProduct}
      />
    </Container>
  );
}

export default App;
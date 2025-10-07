import { useState, useEffect } from 'react';
import api from '../services/api';
import { TextField, Button, Box, Typography } from '@mui/material';

function ProductForm({ onProductCreated, productToEdit, onProductUpdated, onCancelEdit }) {
  
  const initialFormState = {
    nome: '',
    categoria: '',
    preco: '',
    quantidadeEmEstoque: ''
  };

  const [formData, setFormData] = useState(initialFormState);
  
  useEffect(() => {
    if (productToEdit) {
      setFormData({
        nome: productToEdit.nome,
        categoria: productToEdit.categoria,
        preco: productToEdit.preco,
        quantidadeEmEstoque: productToEdit.quantidadeEmEstoque
      });
    } else {
      setFormData(initialFormState);
    }
  }, [productToEdit]);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData(prevState => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const productToSend = {
        ...formData,
        preco: parseFloat(formData.preco),
        quantidadeEmEstoque: parseInt(formData.quantidadeEmEstoque, 10)
      };

      if (productToEdit) {
        const response = await api.put(`/produtos/${productToEdit.id}`, productToSend);
        onProductUpdated(response.data);
      } else {
        const response = await api.post('/produtos', productToSend);
        onProductCreated(response.data);
      }
      
      setFormData(initialFormState);

    } catch (error) {
      console.error("Erro ao salvar produto:", error);
      alert("Falha ao salvar o produto!");
    }
  };

  return (
    <Box 
      component="form" 
      onSubmit={handleSubmit}
      sx={{ display: 'flex', flexDirection: 'column', gap: 2, marginBottom: 4, padding: 2, border: '1px solid #ccc', borderRadius: '8px' }}
    >
      <Typography variant="h6">{productToEdit ? 'Editar Produto' : 'Adicionar Novo Produto'}</Typography>
      <TextField label="Nome" name="nome" value={formData.nome} onChange={handleChange} required fullWidth />
      <TextField label="Categoria" name="categoria" value={formData.categoria} onChange={handleChange} required fullWidth />
      <TextField label="Preço" name="preco" type="number" value={formData.preco} onChange={handleChange} required fullWidth />
      <TextField label="Quantidade em Estoque" name="quantidadeEmEstoque" type="number" value={formData.quantidadeEmEstoque} onChange={handleChange} required fullWidth />
      
      <Box sx={{ display: 'flex', gap: 1 }}>
        <Button type="submit" variant="contained" color="primary">
          {productToEdit ? 'Salvar Alterações' : 'Adicionar Produto'}
        </Button>
        {productToEdit && <Button variant="outlined" onClick={onCancelEdit}>Cancelar</Button>}
      </Box>
    </Box>
  );
}

export default ProductForm;
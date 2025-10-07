import { 
  Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, IconButton 
} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

function ProductList({ products, onEdit, onDelete }) {
  
  if (!products || products.length === 0) {
    return <p>Nenhum produto cadastrado ou carregando...</p>;
  }

  return (
    <TableContainer component={Paper} sx={{ marginTop: 4 }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Nome</TableCell>
            <TableCell>Categoria</TableCell>
            <TableCell align="right">Preço</TableCell>
            <TableCell align="right">Estoque</TableCell>
            <TableCell>Disponível</TableCell>
            <TableCell align="center">Ações</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {products.map((product) => (
            <TableRow key={product.id}>
              <TableCell>{product.nome}</TableCell>
              <TableCell>{product.categoria}</TableCell>
              <TableCell align="right">{`R$ ${product.preco.toFixed(2)}`}</TableCell>
              <TableCell align="right">{product.quantidadeEmEstoque}</TableCell>
              <TableCell>{product.disponivel ? 'Sim' : 'Não'}</TableCell>
              <TableCell align="center">
                <IconButton onClick={() => onEdit(product)} color="primary">
                  <EditIcon />
                </IconButton>
                <IconButton onClick={() => onDelete(product.id)} color="error">
                  <DeleteIcon />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default ProductList;
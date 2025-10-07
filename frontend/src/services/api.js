import axios from 'axios';

// Se não encontrar  URL da API de uma variável de ambiente (para o Docker), usa a URL de desenvolvimento local como padrão.
const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5255/api';

const api = axios.create({
  baseURL: API_URL
});

export default api;
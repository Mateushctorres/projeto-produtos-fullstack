# Estágio 1: Build (construção)
# Usamos uma imagem do Node.js para instalar as dependências e construir o projeto
FROM node:20-alpine AS build
WORKDIR /app

# Copia os package.json e instala as dependências primeiro para aproveitar o cache do Docker
COPY package*.json ./
RUN npm install

# Copia o resto do código da aplicação
COPY . .

# Executa o script de build que gera os arquivos estáticos na pasta /dist
RUN npm run build

# Estágio 2: Serve (servidor)
# Usamos uma imagem super leve do Nginx para servir os arquivos estáticos
FROM nginx:stable-alpine AS final
# Copia os arquivos construídos no estágio anterior para a pasta padrão do Nginx
COPY --from=build /app/dist /usr/share/nginx/html

# Copia o arquivo de configuração customizado do Nginx (vamos criá-lo a seguir)
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expõe a porta 80, que é a porta padrão do Nginx
EXPOSE 80

# Comando para iniciar o Nginx
CMD ["nginx", "-g", "daemon off;"]
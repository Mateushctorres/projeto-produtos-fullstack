# Projeto Gestão de Produtos (Full-Stack)
Aplicação Full-Stack completa para gerenciamento de produtos, desenvolvida com uma API RESTful em .NET 9 e um frontend em React. O sistema foi totalmente containerizado com Docker.

# Tecnologias Utilizadas
Este projeto foi construído utilizando um stack moderno e robusto, com foco em boas práticas de arquitetura e desenvolvimento.

# Backend
* .NET 9 e ASP.NET Core para a construção da API RESTful.
* Arquitetura em Camadas com princípios de Domain-Driven Design (DDD).
* Entity Framework Core 8 como ORM.
* SQLite como banco de dados relacional.
* FluentValidation para validação de dados.
* XUnit para testes unitários da camada de domínio.

# Frontend
* React com Vite para uma experiência de desenvolvimento rápida.
* JavaScript com sintaxe JSX.
* Axios para comunicação com a API.
* Material-UI (MUI)** para a biblioteca de componentes visuais.

# DevOps
* Docker e Docker Compose para containerização e orquestração completa da aplicação.

# Funcionalidades
* CRUD completo de Produtos (Criar, Ler, Atualizar, Deletar).
* API RESTful documentada com Swagger.
* Interface reativa que se atualiza em tempo real, sem necessidade de recarregar a página.
* Persistência de dados em um banco de dados relacional.

# Como Executar o Projeto (Com Docker - Recomendado)
A maneira mais simples e recomendada para executar o projeto completo é utilizando o Docker.

# Pré-requisitos
* Docker Desktop instalado e em execução.

# Instruções
1.  Clone o repositório:
    ```bash
    git clone [https://github.com/mateushctorres/projeto-produtos-fullstack.git](https://github.com/mateushctorres/projeto-produtos-fullstack.git)
    ```
2.  Navegue até a pasta raiz do projeto:
    ```bash
    cd projeto-produtos-fullstack
    ```
3.  Execute o Docker Compose. Ele irá construir as imagens e iniciar os contêineres:
    ```bash
    docker-compose up --build
    ```
4.  Após a conclusão, a aplicação estará disponível nos seguintes endereços:
    * Frontend (Aplicação React): [http://localhost:3000](http://localhost:3000)
    * Backend (Swagger UI da API): [http://localhost:5001/swagger](http://localhost:5001/swagger)

Para parar a aplicação, pressione `Ctrl+C` no terminal e depois execute `docker-compose down`.


# Como Executar Localmente (Sem Docker)
Caso prefira rodar os serviços localmente.

# Pré-requisitos
* .NET SDK 9.0 ou superior.
* Node.js 20.x ou superior.

# Backend
1.  Abra um terminal na pasta raiz do projeto.
2.  Execute o comando:
    ```bash
    dotnet run --project Produto.API/Produto.API.csproj
    ```
3.  A API estará rodando (verifique a porta no terminal, geralmente `http://localhost:5255`).

# Frontend
1.  Abra um segundo terminal.
2.  Navegue até a pasta `frontend`:
    ```bash
    cd frontend
    ```
3.  Instale as dependências (apenas na primeira vez):
    ```bash
    npm install
    ```
4.  Inicie o servidor de desenvolvimento:
    ```bash
    npm run dev
    ```
5.  A aplicação estará disponível em `http://localhost:5173`.

# Autor
Desenvolvido por Mateus Torres.

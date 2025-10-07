# Estágio 1: Build (construção)
# Usamos a imagem completa do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de projeto (.csproj) e o arquivo da solução (.sln)
COPY "SolucaoProduto.sln" .
COPY Produto.API/*.csproj ./Produto.API/
COPY Produto.Application/*.csproj ./Produto.Application/
COPY Produto.Domain/*.csproj ./Produto.Domain/
COPY Produto.Infrastructure/*.csproj ./Produto.Infrastructure/
COPY Produto.Tests/*.csproj ./Produto.Tests/

# Restaura as dependências (pacotes NuGet)
RUN dotnet restore

# Copia todo o resto do código-fonte
COPY . .

# Publica a aplicação, gerando os arquivos otimizados para execução
RUN dotnet publish "Produto.API/Produto.API.csproj" -c Release -o /app/publish

# Estágio 2: Runtime (execução)
# Usamos uma imagem muito menor, apenas com o necessário para rodar a API
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta que o contêiner irá expor
EXPOSE 8080
# Define a variável de ambiente para a ASP.NET Core escutar na porta 8080
ENV ASPNETCORE_URLS=http://+:8080

# Comando para iniciar a API quando o contêiner for executado
ENTRYPOINT ["dotnet", "Produto.API.dll"]
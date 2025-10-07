using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Produto.Application.Services;
using Produto.Application.Validators;
using Produto.Domain.Interfaces;
using Produto.Infrastructure.Data;
using Produto.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// 'produtos.db' como banco de dados.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=produtos.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// Suporte a Controllers
builder.Services.AddControllers();

// Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// FluentValidation para validar os DTOs
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CriarProdutoDtoValidator>();

// Repositório do Entity Framework.
// Scoped, padrão para serviços que usam EF Core.
builder.Services.AddScoped<IProdutoRepository, EfProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

// CORS para permitir que o frontend acesse a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);
// ---------------------------

// Configurar o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// REMOVA O BLOCO QUE ESTAVA AQUI ANTES

app.Run();
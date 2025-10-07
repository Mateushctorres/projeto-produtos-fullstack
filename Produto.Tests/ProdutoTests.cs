using Produto.Domain.Entities;
using Xunit;
using ProdutoEntity = Produto.Domain.Entities.Produto; 

namespace Produto.Tests.Domain
{
    public class ProdutoTests
    {
        // Teste 1: Verifica se o construtor preenche os dados corretamente.
        [Fact]
        public void Produto_Construtor_DeveCriarProdutoComDadosCorretos()
        {
            var nome = "Notebook Gamer";
            var categoria = "Eletrônicos";
            var preco = 7500.50m;
            var quantidade = 10;
            var produto = new ProdutoEntity(nome, categoria, preco, quantidade);

            Assert.Equal(nome, produto.Nome);
            Assert.Equal(categoria, produto.Categoria);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(quantidade, produto.QuantidadeEmEstoque);
            Assert.NotEqual(Guid.Empty, produto.Id);
        }

        // Teste 2: Verifica a regra de negócio "Disponivel" quando há estoque.
        [Fact]
        public void Produto_ComEstoqueMaiorQueZero_DeveEstarDisponivel()
        {
            var produto = new ProdutoEntity("Mouse sem fio", "Periféricos", 150, 5);
            var disponivel = produto.Disponivel;

            Assert.True(disponivel);
        }

        // Teste 3: Verifica a regra de negócio "Disponivel" quando não há estoque.
        [Fact]
        public void Produto_ComEstoqueIgualAZero_NaoDeveEstarDisponivel()
        {
            var produto = new ProdutoEntity("Teclado Mecânico", "Periféricos", 350, 0); 
            var disponivel = produto.Disponivel;

            Assert.False(disponivel);
        }
    }
}
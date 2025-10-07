using Produto.Domain.Entities;
using Produto.Domain.Interfaces;

namespace Produto.Infrastructure.Repositories
{
    public class InMemoryProdutoRepository : IProdutoRepository
    {
        // A lista estática garante que os dados persistam enquanto a aplicação estiver rodando.
        private static readonly List<Domain.Entities.Produto> _produtos = new();

        public Task AdicionarAsync(Domain.Entities.Produto produto)
        {
            _produtos.Add(produto);
            return Task.CompletedTask;
        }

        public Task AtualizarAsync(Domain.Entities.Produto produto)
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExistente != null)
            {
                // Chama o método da própria entidade para atualizar os dados
                produtoExistente.Atualizar(produto.Nome, produto.Categoria, produto.Preco, produto.QuantidadeEmEstoque);
            }
            return Task.CompletedTask;
        }

        public Task<Domain.Entities.Produto?> ObterPorIdAsync(Guid id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(produto);
        }

        public Task<IEnumerable<Domain.Entities.Produto>> ObterTodosAsync()
        {
            return Task.FromResult<IEnumerable<Domain.Entities.Produto>>(_produtos);
        }

        public Task RemoverAsync(Guid id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
            return Task.CompletedTask;
        }
    }
}
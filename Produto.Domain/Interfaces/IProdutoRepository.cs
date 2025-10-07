using Produto.Domain.Entities;
using ProdutoEntity = Produto.Domain.Entities.Produto; 

namespace Produto.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task AdicionarAsync(ProdutoEntity produto);
        Task<ProdutoEntity?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<ProdutoEntity>> ObterTodosAsync();
        Task AtualizarAsync(ProdutoEntity produto);
        Task RemoverAsync(Guid id);
    }
}
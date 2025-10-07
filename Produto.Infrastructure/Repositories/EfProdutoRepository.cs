using Microsoft.EntityFrameworkCore;
using Produto.Domain.Interfaces;
using Produto.Infrastructure.Data;
using ProdutoEntity = Produto.Domain.Entities.Produto;

namespace Produto.Infrastructure.Repositories
{
    public class EfProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public EfProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(ProdutoEntity produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<ProdutoEntity?> ObterPorIdAsync(Guid id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProdutoEntity>> ObterTodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task AtualizarAsync(ProdutoEntity produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var produto = await ObterPorIdAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
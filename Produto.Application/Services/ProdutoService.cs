using Produto.Application.DTOs;
using Produto.Domain.Interfaces;
using Produto.Domain.Entities; 

namespace Produto.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        // Injeção de Dependência
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto criarProdutoDto)
        {
            // Mapear o DTO de entrada para a Entidade de Domínio
            var produtoEntity = new Domain.Entities.Produto(
                criarProdutoDto.Nome,
                criarProdutoDto.Categoria,
                criarProdutoDto.Preco,
                criarProdutoDto.QuantidadeEmEstoque
            );

            // Chamar o repositório para persistir a entidade
            await _produtoRepository.AdicionarAsync(produtoEntity);

            // Mapear a entidade (agora com Id e DataDeInclusao) para o DTO de resposta
            var produtoDto = new ProdutoDto
            {
                Id = produtoEntity.Id,
                Nome = produtoEntity.Nome,
                Categoria = produtoEntity.Categoria,
                Preco = produtoEntity.Preco,
                QuantidadeEmEstoque = produtoEntity.QuantidadeEmEstoque,
                DataDeInclusao = produtoEntity.DataDeInclusao,
                Disponivel = produtoEntity.Disponivel
            };

            return produtoDto;
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodosAsync()
        {
            var produtosEntities = await _produtoRepository.ObterTodosAsync();

            // Mapear a lista de entidades para uma lista de DTOs
            return produtosEntities.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Categoria = p.Categoria,
                Preco = p.Preco,
                QuantidadeEmEstoque = p.QuantidadeEmEstoque,
                DataDeInclusao = p.DataDeInclusao,
                Disponivel = p.Disponivel
            });
        }

        public async Task<ProdutoDto?> ObterPorIdAsync(Guid id)
        {
            var produtoEntity = await _produtoRepository.ObterPorIdAsync(id);

            // Se o repositório não retornar nada, o serviço também não retorna nada.
            if (produtoEntity == null)
            {
                return null;
            }

            // Se encontrou, mapeia a entidade para o DTO de resposta.
            var produtoDto = new ProdutoDto
            {
                Id = produtoEntity.Id,
                Nome = produtoEntity.Nome,
                Categoria = produtoEntity.Categoria,
                Preco = produtoEntity.Preco,
                QuantidadeEmEstoque = produtoEntity.QuantidadeEmEstoque,
                DataDeInclusao = produtoEntity.DataDeInclusao,
                Disponivel = produtoEntity.Disponivel
            };

            return produtoDto;
        }

        public async Task<ProdutoDto?> AtualizarAsync(Guid id, AtualizarProdutoDto atualizarProdutoDto)
        {
            // Verifica se o produto existe
            var produtoEntity = await _produtoRepository.ObterPorIdAsync(id);
            if (produtoEntity == null)
            {
                return null; // Retorna nulo se não encontrar
            }

            // Atualiza a entidade com os novos dados do DTO
            produtoEntity.Atualizar(
                atualizarProdutoDto.Nome,
                atualizarProdutoDto.Categoria,
                atualizarProdutoDto.Preco,
                atualizarProdutoDto.QuantidadeEmEstoque
            );

            // Persiste a entidade atualizada no repositório
            await _produtoRepository.AtualizarAsync(produtoEntity);

            // Mapeia a entidade atualizada para um DTO de resposta
            return new ProdutoDto
            {
                Id = produtoEntity.Id,
                Nome = produtoEntity.Nome,
                Categoria = produtoEntity.Categoria,
                Preco = produtoEntity.Preco,
                QuantidadeEmEstoque = produtoEntity.QuantidadeEmEstoque,
                DataDeInclusao = produtoEntity.DataDeInclusao,
                Disponivel = produtoEntity.Disponivel
            };
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            // Verifica se o produto existe
            var produtoEntity = await _produtoRepository.ObterPorIdAsync(id);
            if (produtoEntity == null)
            {
                return false; // Retorna falso se não encontrar
            }

            // Se existe, pede ao repositório para remover
            await _produtoRepository.RemoverAsync(id);
            return true; // Retorna verdadeiro indicando sucesso
        }
    }
}
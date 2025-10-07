using Microsoft.AspNetCore.Mvc;
using Produto.Application.DTOs;
using Produto.Application.Services;

namespace Produto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //rota base
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodosAsync();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto criarProdutoDto)
        {
            // A validação do FluentValidation já é executada automaticamente pelo ASP.NET Core
            // antes de chegar aqui. Se o DTO for inválido, ele retorna um erro 400 Bad Request.

            var produtoCriado = await _produtoService.CriarProdutoAsync(criarProdutoDto);

            // Retorna o status 201 Created com o local do novo recurso e o objeto criado.
            return CreatedAtAction(nameof(ObterTodos), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);

            // Se o serviço não encontrar o produto, retorna um 404 Not Found.
            if (produto == null)
            {
                return NotFound();
            }

            // Se encontrar, retorna 200 OK com o produto.
            return Ok(produto);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoDto atualizarProdutoDto)
        {
            var produtoAtualizado = await _produtoService.AtualizarAsync(id, atualizarProdutoDto);

            if (produtoAtualizado == null)
            {
                return NotFound(); // Retorna 404 se o produto não existir
            }

            return Ok(produtoAtualizado); // Retorna 200 OK com o produto atualizado
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Deletar(Guid id)
        {
            var sucesso = await _produtoService.DeletarAsync(id);

            if (!sucesso)
            {
                return NotFound(); // Retorna 404 se o produto não foi encontrado
            }

            // Retorna 204 No Content, que é o padrão para uma operação de delete bem-sucedida.
            return NoContent(); 
        }
    }
}
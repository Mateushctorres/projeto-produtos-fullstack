using System.ComponentModel.DataAnnotations;

namespace Produto.Application.DTOs
{
    // DTO usado para receber os dados de criação de um novo produto.
    public class CriarProdutoDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]  
        public string Categoria { get; set; } = string.Empty;

        [Required]
        public decimal Preco { get; set; } = 0;

        [Required]
        public int QuantidadeEmEstoque { get; set; }
    }
}
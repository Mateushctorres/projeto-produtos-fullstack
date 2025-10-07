namespace Produto.Application.DTOs
{
    // DTO usado para retornar os dados completos de um produto.
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public bool Disponivel { get; set; }
    }
}
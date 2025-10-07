namespace Produto.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Categoria { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public DateTime DataDeInclusao { get; private set; }

        public bool Disponivel => QuantidadeEmEstoque > 0;

        public Produto(string nome, string categoria, decimal preco, int quantidadeEmEstoque)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            DataDeInclusao = DateTime.UtcNow;
        }

        public void Atualizar(string nome, string categoria, decimal preco, int quantidadeEmEstoque)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }
    }
}
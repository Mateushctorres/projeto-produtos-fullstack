using FluentValidation;
using Produto.Application.DTOs;

namespace Produto.Application.Validators
{
    public class AtualizarProdutoDtoValidator : AbstractValidator<AtualizarProdutoDto>
    {
        public AtualizarProdutoDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(3, 100).WithMessage("O nome do produto deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Categoria)
                .NotEmpty().WithMessage("A categoria do produto é obrigatória.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(x => x.QuantidadeEmEstoque)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");
        }
    }
}
using FluentValidation;
using Microservice.Produtos.Services.Models;

namespace Microservice.Produtos.Services.Validators
{
    public class ProdutoModelValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoModelValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Objeto produto não foi informado.");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Identificador inválido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do produto deve ser informado");

            RuleFor(x => x.PrecoDeCusto)
                .GreaterThan(0).WithMessage("O preço de custo deve ser maior que zero."); ;

            RuleFor(x => x.PrecoDeVenda)
                .GreaterThan(0).WithMessage("O preço de venda deve ser maior que zero.");

            RuleFor(x => x.CategoriaDoProduto)
                .InjectValidator();
        }
    }
}
using FluentValidation;
using Microservice.Produtos.Services.Models;

namespace Microservice.Produtos.Services.Validators
{
    public class CategoriaDoProdutoValidator : AbstractValidator<CategoriaDoProdutoModel>
    {
        public CategoriaDoProdutoValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Objeto categoria do produto não foi informado.");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Identificador inválido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da categoria do produto deve ser informado");
        }
    }
}
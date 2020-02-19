using FluentValidation;
using Microservice.Produtos.Services.Models;
using System;

namespace Microservice.Produtos.Services.Validators
{
    public class ProdutoModelValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoModelValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Objeto produto não foi informado.");

            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Identificador inválido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do produto deve ser informado");
        }
    }
}
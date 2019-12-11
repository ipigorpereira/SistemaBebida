using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class EstoqueValidator : AbstractValidator<Estoque>
    {
        public EstoqueValidator()
        {
            RuleFor(x => x.EstoqueId).NotEmpty().NotNull().WithMessage("Estoque adicionada sem ID");

            RuleFor(x => x.BebidaId).NotEmpty().NotNull().WithMessage("Estoque deve ser atrelado a bebida");

            

        }
    }
}

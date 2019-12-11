using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class VendaBebidaValidator : AbstractValidator<VendaBebida>
    {
        public VendaBebidaValidator()
        {
            RuleFor(x => x.VendaBebidaId).NotEmpty().NotNull().WithMessage("VendaBebida adicionada sem ID");

            RuleFor(x => x.BebidaId).NotEmpty().NotNull().WithMessage("Venda de Bebida deve ter bebida");

            RuleFor(x => x.VendaId).NotEmpty().NotNull().WithMessage("venda Bebida deve estar atrelado a alguma venda");

            

        }
    }
}

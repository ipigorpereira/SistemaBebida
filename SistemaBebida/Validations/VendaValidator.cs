using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(x => x.VendaId).NotEmpty().NotNull().WithMessage("Venda adicionada sem ID");

            RuleFor(x => x.ClienteId).NotEmpty().NotNull().WithMessage("venda deve ter cliente");

            RuleFor(x => x.Data).NotEmpty().NotNull().WithMessage("Venda deve ter data");

           

        }
    }
}

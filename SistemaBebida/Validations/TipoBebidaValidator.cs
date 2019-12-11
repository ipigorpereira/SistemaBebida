using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class TipoBebidaValidator : AbstractValidator<TipoBebida>
    {
        public TipoBebidaValidator()
        {
            RuleFor(x => x.TipoBebidaId).NotEmpty().NotNull().WithMessage("Tipo de bebida adicionada sem ID");

            RuleFor(x => x.Tipo).NotEmpty().NotNull().WithMessage("Tipo de bebida deve ter nome");


        }
    }
}

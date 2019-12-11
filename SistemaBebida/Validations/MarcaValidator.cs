using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class MarcaValidator : AbstractValidator<Marca>
    {
        public MarcaValidator()
        {
            RuleFor(x => x.MarcaId).NotEmpty().NotNull().WithMessage("Marca adicionada sem ID");

            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Marca deve ter nome");


        }
    }
}

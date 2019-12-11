using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.ClienteId).NotEmpty().NotNull().WithMessage("Cliente adicionado sem ID");

            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Cliente deve ter nome");

            

        }
    }
}

using FluentValidation;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public class BebidaValidator : AbstractValidator<Bebida>
    {

        public BebidaValidator()
        {
            RuleFor(x => x.BebidaId).NotEmpty().NotNull().WithMessage("Bebida adicionada sem ID");

            RuleFor(x => x.Descricao).NotEmpty().NotNull().WithMessage("Bebida deve ter nome");

            RuleFor(x => x.Valor).NotEmpty().NotNull().WithMessage("Bebida deve ter preco");

            RuleFor(x => x.Marca).NotEmpty().NotNull().WithMessage("Bebida deve ter marca");

            RuleFor(x => x.TipoBebida).NotEmpty().NotNull().WithMessage("Bebida deve ter tipo");

        }
        
    }
}

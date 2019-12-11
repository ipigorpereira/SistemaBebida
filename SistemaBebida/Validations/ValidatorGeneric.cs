using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Validations
{
    public static class ValidatorGeneric
    {
        public static Task Validar<TValidator, TEntity>(this TEntity entity)
            where TValidator : AbstractValidator<TEntity>, new()
        {
            var validator = new TValidator();
            return validator.ValidateAndThrowAsync(entity);
        }

    }
}

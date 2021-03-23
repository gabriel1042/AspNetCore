using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class StateValidation : AbstractValidator<State>
    {
        public StateValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Initial)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 2)
                .WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres");
        }
    }
}

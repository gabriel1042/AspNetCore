using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class BankValidation : AbstractValidator<Bank>
    {
        public BankValidation()
        {
            RuleFor(b => b.Code)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}

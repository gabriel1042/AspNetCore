using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class CheckValidation : AbstractValidator<Check>
    {
        public CheckValidation()
        {
            RuleFor(c => c.Issuer)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 255)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Number)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.PaymentId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.BankId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}

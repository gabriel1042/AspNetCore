using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace erp_usitronic.business.models.Validations
{
    public class FinancialMovementValidation : AbstractValidator<FinancialMovement>
    {
        public FinancialMovementValidation()
        {
            RuleFor(c => c.TransactionValue)
            .GreaterThan(0)
            .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.TransactionDate)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Kind)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(a => a.BankId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}

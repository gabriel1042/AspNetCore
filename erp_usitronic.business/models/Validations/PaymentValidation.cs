using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(c => c.PaymentDate)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.PaymentValue)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.CompanyId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.KindPayment)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 255)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.SupplierId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.BankId)
                .GreaterThan(0)
                .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Paid)
                .Equal(false)
                .WithMessage("Não é permitido alterar o status do campo {PropertyName} pelo método update.");
        }
    }
}

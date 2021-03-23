using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 255)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.CnpjNumber)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(14,14)
                .WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres");

            RuleFor(c => c.StateRegistration)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}

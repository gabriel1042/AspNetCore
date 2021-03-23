using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 255)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.KindPerson)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            When(c => c.KindPerson == 'F', () => {
                RuleFor(c => c.IdNumber)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11, 11)
                .WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres");
            }).Otherwise(() => {
                RuleFor(c => c.IdNumber)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(14, 14)
                .WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres");
            });
        }
    }
}

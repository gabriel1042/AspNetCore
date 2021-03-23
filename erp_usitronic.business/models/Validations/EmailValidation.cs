using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.models.Validations
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(c => c.Description)
                .EmailAddress();
        }
    }
}

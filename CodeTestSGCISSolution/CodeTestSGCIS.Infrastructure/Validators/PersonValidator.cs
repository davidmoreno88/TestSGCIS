using CodeTestSGCIS.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTestSGCIS.Infrastructure.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name)
                .NotNull()
                .MaximumLength(200);

        }
    }
}

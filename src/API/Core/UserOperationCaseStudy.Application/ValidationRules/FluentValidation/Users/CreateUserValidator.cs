using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser;

namespace UserOperationCaseStudy.Application.ValidationRules.FluentValidation.Users
{
    public class CreateUserValidator: AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.Surname).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.BirthDate).NotEmpty();
        }
    }
}

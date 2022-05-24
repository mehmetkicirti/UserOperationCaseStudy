using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.Users.Commands.UpdateUser;

namespace UserOperationCaseStudy.Application.ValidationRules.FluentValidation.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.Surname).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.BirthDate).NotEmpty();
        }
    }
}

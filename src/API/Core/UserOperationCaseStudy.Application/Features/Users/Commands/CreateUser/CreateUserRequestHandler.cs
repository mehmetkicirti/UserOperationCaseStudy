using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Application.ValidationRules.FluentValidation.Users;
using UserOperationCaseStudy.Common.Aspects.Autofac.Validation;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserRequestHandler : UserRequestHandler, IRequestHandler<CreateUserRequest, IResponse>
    {
        public CreateUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [ValidationAspect(typeof(CreateUserValidator))]
        public Task<IResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

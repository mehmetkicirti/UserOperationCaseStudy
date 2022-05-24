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
using UserOperationCaseStudy.Common.Constants;
using UserOperationCaseStudy.Common.Helpers.Application;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;
using UserOperationCaseStudy.Common.Wrappers.Concretes;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserRequestHandler : UserRequestHandler, IRequestHandler<CreateUserRequest, IResponse>
    {
        public CreateUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [ValidationAspect(typeof(CreateUserValidator))]
        public async Task<IResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = iMapper.Map<User>(request);
            user.ImagePath = await FileHelper.AddAsync(request.Image);
            await iRepository.AddAsync(user);

            return new ServiceResponse(ResponseConstants.CREATE_ENTITY_SUCCESSFULLY);
        }
    }
}

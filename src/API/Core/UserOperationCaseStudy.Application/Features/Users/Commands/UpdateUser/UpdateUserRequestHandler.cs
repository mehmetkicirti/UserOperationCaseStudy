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
using UserOperationCaseStudy.Common.Exceptions;
using UserOperationCaseStudy.Common.Helpers.Application;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;
using UserOperationCaseStudy.Common.Wrappers.Concretes;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserRequestHandler : UserRequestHandler, IRequestHandler<UpdateUserRequest, IResponse>
    {
        public UpdateUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [ValidationAspect(typeof(UpdateUserValidator))]
        public async Task<IResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (ApplicationRules.RunLogicsAsync(IsUserExists(request.Id)) == null)
            {
                var user = await iRepository.GetByIdAsync(request.Id);

                if (Guid.Parse(request.Id) == user.Id)
                {
                    var newUser = iMapper.Map<User>(request);
                    await Task.Factory.StartNew(() => iRepository.Update(newUser));
                    return new ServiceResponse(ResponseConstants.UPDATE_ENTITY_SUCCESFULLY);
                }
                throw new DatabaseException(ExceptionConstants.RECORD_NOT_SAVED_ERROR);
            }
            throw new DatabaseException(ExceptionConstants.USER_NOT_EXIST_ERROR);
        }
    }
}

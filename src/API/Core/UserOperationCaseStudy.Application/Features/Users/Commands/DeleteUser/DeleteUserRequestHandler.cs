using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Constants;
using UserOperationCaseStudy.Common.Exceptions;
using UserOperationCaseStudy.Common.Helpers.Application;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;
using UserOperationCaseStudy.Common.Wrappers.Concretes;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserRequestHandler : UserRequestHandler, IRequestHandler<DeleteUserRequest, IResponse>
    {
        public DeleteUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            if (ApplicationRules.RunLogicsAsync(IsUserExists(request.Id)) == null)
            {
                var user = await iRepository.GetByIdAsync(request.Id);
                await Task.Factory.StartNew(() => iRepository.Delete(user));
                return new ServiceResponse(ResponseConstants.DELETE_ENTITY_SUCCESFULLY);
            }

            throw new DatabaseException(ResponseConstants.DELETE_ENTITY_FAILED, BadRequestCode);
        }
    }
}

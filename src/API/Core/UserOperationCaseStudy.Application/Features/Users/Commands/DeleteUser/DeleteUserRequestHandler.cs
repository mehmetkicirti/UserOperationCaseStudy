using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserRequestHandler : UserRequestHandler, IRequestHandler<DeleteUserRequest, IResponse>
    {
        public DeleteUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<IResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

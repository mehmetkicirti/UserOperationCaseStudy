using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserRequestHandler : UserRequestHandler, IRequestHandler<UpdateUserRequest, IResponse>
    {
        public UpdateUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<IResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

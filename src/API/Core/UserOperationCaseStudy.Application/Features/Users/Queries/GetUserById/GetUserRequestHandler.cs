using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.ViewModels;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Queries.GetUserById
{
    public class GetUserRequestHandler : UserRequestHandler, IRequestHandler<GetUserRequest, IDataResponse<UserViewModel>>
    {
        public GetUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<IDataResponse<UserViewModel>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

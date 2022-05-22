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

namespace UserOperationCaseStudy.Application.Features.Users.Queries.GetUsers
{
    public class GetAllUsersRequestHandler : UserRequestHandler, IRequestHandler<GetAllUsersRequest, IDataResponse<IReadOnlyList<UserViewModel>>>
    {
        public GetAllUsersRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<IDataResponse<IReadOnlyList<UserViewModel>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

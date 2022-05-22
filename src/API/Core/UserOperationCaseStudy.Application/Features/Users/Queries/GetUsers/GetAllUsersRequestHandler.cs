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
using UserOperationCaseStudy.Common.Wrappers.Concretes;

namespace UserOperationCaseStudy.Application.Features.Users.Queries.GetUsers
{
    public class GetAllUsersRequestHandler : UserRequestHandler, IRequestHandler<GetAllUsersRequest, IDataResponse<IReadOnlyList<UserViewModel>>>
    {
        public GetAllUsersRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IDataResponse<IReadOnlyList<UserViewModel>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await iRepository.GetAllAsync();
            // Loading actions has been working or not 
            await Task.Delay(1500);
            var viewModel = iMapper.Map<IReadOnlyList<UserViewModel>>(users);
            return new DataResponse<IReadOnlyList<UserViewModel>>(viewModel);
        }
    }
}

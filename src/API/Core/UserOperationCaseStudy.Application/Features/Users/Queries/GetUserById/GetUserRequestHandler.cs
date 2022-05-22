using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.ViewModels;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Constants;
using UserOperationCaseStudy.Common.Exceptions;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;
using UserOperationCaseStudy.Common.Wrappers.Concretes;

namespace UserOperationCaseStudy.Application.Features.Users.Queries.GetUserById
{
    public class GetUserRequestHandler : UserRequestHandler, IRequestHandler<GetUserRequest, IDataResponse<UserViewModel>>
    {
        public GetUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IDataResponse<UserViewModel>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await iRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new DatabaseException(ResponseConstants.ENTITY_NOT_EXIST);
            }
            var viewModel = iMapper.Map<UserViewModel>(user);
            return new DataResponse<UserViewModel>(viewModel);
        }
    }
}

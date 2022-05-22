using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Features.ViewModels;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Queries.GetUserById
{
    public class GetUserRequest: IRequest<IDataResponse<UserViewModel>>
    {
        public string Id { get; set; }
    }
}

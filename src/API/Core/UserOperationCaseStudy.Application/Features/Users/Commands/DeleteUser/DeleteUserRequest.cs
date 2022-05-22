using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserRequest: IRequest<IResponse>
    {
        public string Id { get; set; }
    }
}

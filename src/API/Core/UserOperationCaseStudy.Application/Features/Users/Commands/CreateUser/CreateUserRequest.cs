using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;

namespace UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserRequest: IRequest<IResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IFormFile Image { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

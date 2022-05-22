using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Application.Features.Users
{
    public class UserRequestHandler : BaseRequestHandler<IUserRepository, User>
    {
        public UserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        #region Logics
        // Note => It can be same logics into each request query or commands so that we can define here
        #endregion
    }
}

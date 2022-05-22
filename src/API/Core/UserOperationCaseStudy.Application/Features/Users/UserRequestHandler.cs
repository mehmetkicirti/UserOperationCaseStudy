using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Constants;
using UserOperationCaseStudy.Common.Wrappers.Abstracts;
using UserOperationCaseStudy.Common.Wrappers.Concretes;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Application.Features.Users
{
    public class UserRequestHandler : BaseRequestHandler<IUserRepository, User>
    {
        public const int BadRequestCode = (int)HttpStatusCode.BadRequest;
        public UserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        #region Logics
        // Note => It can be same logics into each request query or commands so that we can define here
        protected async Task<IResponse> IsUserExists(string userId)
        {
            if (CheckObjectIdIsNotNull(userId))
            {
                var user = await iRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return new ErrorResponse(ResponseConstants.ENTITY_NOT_EXIST, BadRequestCode);
                }
                return new ServiceResponse(true);
            }
            return new ErrorResponse(ResponseConstants.GUID_IS_NOT_NULL, BadRequestCode);
        }

        private bool CheckObjectIdIsNotNull(string id) => id != null ? true : false;
        #endregion
    }
}

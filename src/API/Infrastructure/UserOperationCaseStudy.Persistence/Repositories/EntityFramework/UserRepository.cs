using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Common.Repository;
using UserOperationCaseStudy.Domain.Entities;
using UserOperationCaseStudy.Persistence.Contexts;

namespace UserOperationCaseStudy.Persistence.Repositories.EntityFramework
{
    public class UserRepository : BaseGenericRepository<User, UserOperationDBContext>, IUserRepository
    {
        public UserRepository(UserOperationDBContext context) : base(context)
        {
        }
    }
}

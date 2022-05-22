using Autofac;
using Autofac.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Application.Interfaces;
using UserOperationCaseStudy.Persistence.Contexts;
using UserOperationCaseStudy.Persistence.Repositories.EntityFramework;

namespace UserOperationCaseStudy.Persistence
{
    public class PersistenceRegistrationModule:ConfigurationModule
    {
        public PersistenceRegistrationModule(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            SeedData.SeedAsync(Configuration).GetAwaiter().GetResult();
            builder.RegisterType<UserOperationDBContext>().AsSelf().As<DbContext>().SingleInstance();

            #region Setup Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            #endregion
        }
    }
}

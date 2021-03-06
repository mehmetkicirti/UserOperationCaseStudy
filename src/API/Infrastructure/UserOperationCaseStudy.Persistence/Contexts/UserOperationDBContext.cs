using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Persistence.Contexts
{
    public class UserOperationDBContext: DbContext
    {
        private readonly IConfiguration _iConfiguration;
        public UserOperationDBContext()
        {
        }

        public UserOperationDBContext(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }

        public UserOperationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string sqlServerConnectionString = _iConfiguration.GetConnectionString("DefaultConnection");
            // NOTE => if you want to migrate db, you need to assign as direct connection string.
            optionsBuilder.UseSqlServer(sqlServerConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Persistence.Configurations
{
    public class UserConfiguration: BaseConfigurations<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Name).HasMaxLength(75).IsRequired();
            builder.Property(u => u.Surname).HasMaxLength(75).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired();
            builder.Property(u => u.ImagePath).HasColumnType("ntext").IsRequired();
        }
    }
}

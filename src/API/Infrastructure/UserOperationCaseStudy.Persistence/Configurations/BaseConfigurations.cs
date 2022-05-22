using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Domain.Abstract;

namespace UserOperationCaseStudy.Persistence.Configurations
{
    public abstract class BaseConfigurations<T> : IEntityTypeConfiguration<T>
        where T: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
        }
    }
}

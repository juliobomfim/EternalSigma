using jbDEV_Eternal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jbDEV_Eternal.Infra.Mapping
{
    public class EntityMap<T> : IEntityTypeConfiguration<T>where T:Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Create).IsRequired();
            builder.Property(x => x.Change).IsRequired();
        }
    }
}

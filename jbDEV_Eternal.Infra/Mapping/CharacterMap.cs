using jbDEV_Eternal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jbDEV_Eternal.Infra.Mapping
{
    public class CharacterMap : EntityMap<Character>
    {
        public override void Configure(EntityTypeBuilder<Character> builder)
        {

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            base.Configure(builder);
        }
    }
}

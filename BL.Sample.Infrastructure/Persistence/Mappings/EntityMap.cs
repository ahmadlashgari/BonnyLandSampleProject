using BL.Sample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BL.Sample.Infrastructure.Persistence.Mappings
{
    public class EntityMap : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(150).IsRequired();

            builder.ToTable("Entities");
        }
    }
}

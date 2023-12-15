using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marmelade.Data
{
    internal class LagerortConfiguration : IEntityTypeConfiguration<Lagerort>
    {
        public void Configure(EntityTypeBuilder<Lagerort> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasData(
                new Lagerort
                {
                    Id = 1,
                    Name = "A1"
                }
            );
        }
    }

}
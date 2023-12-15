using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marmelade.Data
{
    internal class LagergegenstandConfiguration : IEntityTypeConfiguration<Lagergegenstand>
    {
        public void Configure(EntityTypeBuilder<Lagergegenstand> builder)
        {
            builder.HasData(
                new Lagergegenstand
                {
                    Id = 1,
                    Name = "Marmelade",
                    LagerortId = 1,
                    Mengenbezeichner = "Gramm",
                    Menge = 500
                    
                }
            );
        }
    }
}
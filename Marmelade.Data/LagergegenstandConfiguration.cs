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
                    Name = "Melonen Marmelade",
                    LagerortId = 1,
                    Mengenbezeichner = "Gramm",
                    Menge = 500,
                    Lagerzeitpunkt = DateTime.Now,
                    Beschreibung = "Frische Fruchtmarmelade",

                    BenutzerId = 2
                },
                new Lagergegenstand
                {
                    Id = 2,
                    Name = "Erdbeer Marmelade",
                    LagerortId = 5,
                    Mengenbezeichner = "Gramm",
                    Menge = 750,
                    Lagerzeitpunkt = DateTime.Now,
                    Beschreibung = "Frische Fruchtmarmelade",
  
                    BenutzerId = 2

                }
            );
           
        }
    }
}
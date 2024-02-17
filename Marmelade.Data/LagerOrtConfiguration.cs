using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marmelade.Data
{
    internal class LagerortConfiguration : IEntityTypeConfiguration<Lagerort>
    {

        List<Lagerort> kuehlschrankA = new List<Lagerort>();
        List<Lagerort> kuehlschrankB = new List<Lagerort>();
        List<Lagerort> kuehlschrankC = new List<Lagerort>();
        public LagerortConfiguration()
        {
            for (int i = 1; i <= 6; i++)
            {
                var ort = new Lagerort
                {
                    Id = i,
                    Beschreibung = "Kühlschrank A",
                    Name = "A" + i.ToString(),
                    BenutzerId = 2,

                };
                kuehlschrankA.Add(ort);
            }//bis id 6
            for (int i = 1; i <= 6; i++)
            {
                var ort = new Lagerort
                {
                    Id = (i + 6),
                    Beschreibung = "Kühlschrank B",
                    Name = "B" + i.ToString(),
                    BenutzerId = 2,
                };
                kuehlschrankB.Add(ort);
            }//bis id 12
            for (int i = 1; i <= 5; i++)
            {
                var ort = new Lagerort
                {
                    Id = (i + 12),
                    Beschreibung = "Kühlschrank C",
                    Name = "C" + i.ToString(),
                    BenutzerId = 2,

                };
                kuehlschrankC.Add(ort);
            }//bis id 17
            kuehlschrankC.AddRange(kuehlschrankA);
            kuehlschrankC.AddRange(kuehlschrankB);
            kuehlschrankC.Add(new Lagerort
            {
                Id = 18,
                Name = "G1",
                Beschreibung = "Kühlschrank G",
                BenutzerId = 2,
            });
            kuehlschrankC.Add(new Lagerort
            {
                Id = 19,
                Name = "G2",
                Beschreibung = "Kühlschrank G",
                BenutzerId = 2,
            });
            kuehlschrankC.Add(new Lagerort
            {
                Id = 20,
                Name = "GA",
                Beschreibung = "Garage",
                BenutzerId = 2,
            });
            kuehlschrankC.Add(new Lagerort
            {
                Id = 21,
                Name = "KE",
                Beschreibung = "Keller",
                BenutzerId = 2,
            });

        }

        public void Configure(EntityTypeBuilder<Lagerort> builder)
        {

            builder.HasIndex(p => new { p.Name, p.BenutzerId }).IsUnique();
 
            builder.HasData(
                kuehlschrankC
            );
        }
    }

}
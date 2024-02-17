using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marmelade.Data
{
    internal class BenutzerConfiguration : IEntityTypeConfiguration<Benutzer>
    {
        public void Configure(EntityTypeBuilder<Benutzer> builder)
        {
            builder.HasData(
                    new Benutzer
                    {
                        Id = 1,
                        Name = "paul",
                        Password = Benutzer.GetPassword("11dänemark")
                    },
                    new Benutzer
                    {
                        Id = 2,
                        Name = "peter",
                        Password = Benutzer.GetPassword("5812password")
                    }
                );
        }
    }

}
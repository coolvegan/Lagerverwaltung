using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marmelade.Data
{
    internal class ApiEinstellungConfiguration : IEntityTypeConfiguration<ApiEinstellung>
    {
        public void Configure(EntityTypeBuilder<ApiEinstellung> builder)
        {
            builder.HasData(
                    new ApiEinstellung
                    {
                        Id = 1,
                        AuthenticationSchluessel = "ChangeMe"
                    }
                );
        }
    }

}
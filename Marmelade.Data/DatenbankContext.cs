using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Marmelade.Data
{
    public class DatenbankContext : DbContext
    {
        public DatenbankContext(DbContextOptions<DatenbankContext> options) : base(options) { }
        public DbSet<Lagergegenstand> Lagergegenstand { get; set; }
        public DbSet<ApiEinstellung> ApiEinstellungen { get; set; }
        public DbSet<Lagerort> Lagerorte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Lagergegenstand>().HasOne(x => x.Lagerort).WithMany(y => y.Lagergegenstand).HasForeignKey(f => f.LagerortId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.ApplyConfiguration(new LagergegenstandConfiguration());
            modelBuilder.ApplyConfiguration(new LagerortConfiguration());
            modelBuilder.ApplyConfiguration(new ApiEinstellungConfiguration());
        }
    }


}

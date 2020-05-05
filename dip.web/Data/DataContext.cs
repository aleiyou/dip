using dip.web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dip.web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DipEntity> Dips { get; set; }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        /* creador de eventos para datos unicos*******************************************++*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DipEntity>()
              .HasIndex(t => t.Plaque)
              .IsUnique();


        }

        /* ****************************************************************************/

    }
}

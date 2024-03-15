using CriteriosDominio.Dominio.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.contexto
{

    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Asterisk");

        }

        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RestriccionesDeZonas> RestriccionesDeZonas { get; set; }
        public DbSet<Fisioterapeuta> Fisioterapeuta { get; set; }
        public DbSet<Sched> Sched { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zona>()
            .Property(z => z.ZonaId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rooms>().HasKey(r => r.RoomId);

            modelBuilder.Entity<RestriccionesDeZonas>()
            .Property(r => r.RestriccionesDeZonasId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Fisioterapeuta>()
            .Property(f => f.FisioterapeutaId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sched>()
            .Property(s => s.SchedId)
            .ValueGeneratedOnAdd();

        }

    }
}

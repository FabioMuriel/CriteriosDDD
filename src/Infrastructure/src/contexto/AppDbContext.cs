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
            modelBuilder.Entity<Zona>().HasKey(z => z.ZonaId);
            modelBuilder.Entity<Rooms>().HasKey(r => r.RoomId);
            modelBuilder.Entity<RestriccionesDeZonas>().HasKey(rz => rz.RestriccionesDeZonasId);
            modelBuilder.Entity<Fisioterapeuta>().HasKey(f => f.FisioterapeutaId);
            modelBuilder.Entity<Sched>().HasKey(s => s.SchedId);

        }

    }
}

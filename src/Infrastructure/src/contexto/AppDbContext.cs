using CriteriosDominio.Dominio.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RestriccionesDeZonas> RestriccionesDeZonas { get; set; }
        public DbSet<Fisioterapeuta> Fisioterapeutas { get; set; }
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

            modelBuilder.Entity<Sched>()
                .Property(s => s.SchedId)
                .ValueGeneratedOnAdd();

            // Llamamos al método para inicializar los datos
            SeedInitialData(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fisioterapeuta>().HasData(
                new Fisioterapeuta(Guid.NewGuid(), "Juan", "Perez", 10),
                new Fisioterapeuta(Guid.NewGuid(), "Maria", "Gonzalez", 20),
                new Fisioterapeuta(Guid.NewGuid(), "Pedro", "Rodriguez", 30)
            );
        }
    }
}

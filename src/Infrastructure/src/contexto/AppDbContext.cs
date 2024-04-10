using CriteriosDominio.Dominio.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.contexto
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


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

            modelBuilder.Entity<Sched>()
            .Property(s => s.SchedId)
            .ValueGeneratedOnAdd();

            //TODO: Inicializar la informacion de la base de datos
            modelBuilder.Entity<Fisioterapeuta>().HasData(
                new Fisioterapeuta(Guid.NewGuid(), "Juan", "Perez", 10), //Junior
                new Fisioterapeuta(Guid.NewGuid(), "Maria", "Gonzalez", 20), //Senior
                new Fisioterapeuta(Guid.NewGuid(), "Pedro", "Rodriguez", 30) //Master
            );

        }

    }
}

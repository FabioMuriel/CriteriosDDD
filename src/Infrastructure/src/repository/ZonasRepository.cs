using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;

namespace Infrastructure.src.repository
{
    public class ZonasRepository : IZonaRepository
    {
        public ZonasRepository()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Zonas.Any())
                {
                    var zonas = new List<Zona>
                {
                    new Zona
                    {
                        ZonaId = 1,
                        Nombre = "CAMILLA",
                        Rooms = "1-1-1-1-1-1-1-1-1-1-0-0-0-0-0-0-0-0",
                    },
                    new Zona
                    {
                        ZonaId = 2,
                        Nombre = "CAMILLA",
                        Rooms = "0-0-0-0-0-0-0-0-0-0-1-1-1-1-1-1-1-1"
                    }
                };

                    context.Zonas.AddRange(zonas);
                    context.SaveChanges();
                }
            }
        }

        public List<Zona> GetZonas()
        {
            using (var context = new AppDbContext())
            {
                return context.Zonas.ToList();
            }
        }

    }
}
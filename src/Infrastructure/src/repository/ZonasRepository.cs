using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using CriteriosDominio.Dominio.Helpers;

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
                        Nombre = "CAMILLA",
                        Rooms = "1-1-1-1-1-1-1-1-1-1-0-0-0-0-0-0-0-0",
                    },
                    new Zona
                    {
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

        public void AddZona(Zona zona)
        {
            using (var context = new AppDbContext())
            {
                ValidationHelper.ValidateEntity(zona);
                int lasId = context.Zonas.Max(x => x.ZonaId) + 1;
                zona.ZonaId = lasId;
                context.Zonas.Add(zona);
                context.SaveChanges();
            }
        }

        public void UpdateZona(Zona zona)
        {
            using (var context = new AppDbContext())
            {
                ValidationHelper.ValidateEntity(zona);
                context.Zonas.Update(zona);
                context.SaveChanges();
            }
        }

        public void DeleteZona(int id)
        {
            using (var context = new AppDbContext())
            {
                var zona = context.Zonas.Find(id);
                context.Zonas.Remove(zona);
                context.SaveChanges();
            }
        }
    }
}
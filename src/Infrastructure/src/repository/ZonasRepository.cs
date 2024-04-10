using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;

namespace Infrastructure.src.repository
{
    public class ZonasRepository : IZonaRepository
    {

        private readonly AppDbContext _context;

        public ZonasRepository()
        {
            // using (var context = new AppDbContext())
            // {
            //     if (!context.Zonas.Any())
            //     {
            //         var zonas = new List<Zona>
            //     {
            //         new Zona
            //         {
            //             Nombre = "CAMILLA",
            //             Rooms = "1-1-1-1-1-1-1-1-1-1-0-0-0-0-0-0-0-0",
            //         },
            //         new Zona
            //         {
            //             Nombre = "CAMILLA",
            //             Rooms = "0-0-0-0-0-0-0-0-0-0-1-1-1-1-1-1-1-1"
            //         }
            //     };

            //         context.Zonas.AddRange(zonas);
            //         context.SaveChanges();
            //     }
            // }
        }

        public Task AddZona(Zona zona)
        {
            throw new NotImplementedException();
        }

        public Task DeleteZona(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Zona?> GetZonaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zona>> GetZonas()
        {
            throw new NotImplementedException();
        }

        public Task UpdateZona(Zona zona)
        {
            throw new NotImplementedException();
        }
    }
}
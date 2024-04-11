using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.repository
{
    public class ZonasRepository : IZonaRepository
    {

        private readonly AppDbContext _context;

        public ZonasRepository(AppDbContext context)
        {
            _context = context;

            if (_context.Rooms.CountAsync().Result == 0)
            {
                var zonas = new List<Zona>
                {
                    new Zona
                    (
                        Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"),
                        "CAMILLA",
                        "1, 2, 3, 4, 5, 6, 7, 8, 9, 10"
                    ),
                    new Zona
                    (
                        Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"),
                        "MANO",
                        "11, 12, 13, 14, 15, 16, 17"
                    )
                };

                context.Zonas.AddRange(zonas);
                context.SaveChanges();
            }
        }

        public async Task AddZona(Zona zona)
        {
            ValidationHelper.ValidateEntity(zona);

            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteZona(Guid id)
        {
            var zona = await _context.Zonas.FindAsync(id);

            if (zona == null)
            {
                throw new Exception("Zona no encontrada");
            }

            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();
        }

        public async Task<Zona?> GetZonaById(Guid id)
        {
            var zona = await _context.Zonas.FindAsync(id);

            if (zona == null)
            {
                throw new Exception("Zona no encontrada");
            }

            return zona;
        }

        public async Task<IEnumerable<Zona>> GetZonas()
        {
            var zonas = await _context.Zonas.ToListAsync();

            if (zonas == null)
            {
                throw new ArgumentNullException(nameof(zonas));
            }

            return zonas;
        }

        public async Task UpdateZona(Zona zona)
        {
            ValidationHelper.ValidateEntity(zona);

            _context.Zonas.Update(zona);
            await _context.SaveChangesAsync();
        }
    }
}
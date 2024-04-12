using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.repository
{
    public class RestriccionesDeZonasRepository : IRestriccionesDeZonasRepository
    {

        private readonly AppDbContext _context;

        public RestriccionesDeZonasRepository(AppDbContext context)
        {
            _context = context;

            if (_context.RestriccionesDeZonas.CountAsync().Result == 0)
            {
                //TODO: Agregar el resto de criterios
                _context.RestriccionesDeZonas.Add(new RestriccionesDeZonas(
                        Guid.NewGuid(),
                        "Restriccion 1",
                        "1,2,3",
                        "12,13,14",
                        "Los fisioterapeutas ubicados en camillas 1, 2 y 3 solo pueden atender en manos 2, 3 y 4"
                    )
                );

                _context.RestriccionesDeZonas.Add(new RestriccionesDeZonas(
                        Guid.NewGuid(),
                        "Restriccion 2",
                        "4,5,6",
                        "15,16,17",
                        "Los fisioterapeutas ubicados en camillas 4, 5 y 6 solo pueden atender en manos 5, 6 y 7"
                    )
                );

                _context.RestriccionesDeZonas.Add(new RestriccionesDeZonas(
                        Guid.NewGuid(),
                        "Restriccion 3",
                        "1,2.3,4,5,6,7,8,9,10",
                        "1,2,3,4,5,6,7,8,9,10",
                        "Los fisioterapeutas ubicados en camillas pueden programar en cualquier camilla"
                    )
                );

                _context.RestriccionesDeZonas.Add(new RestriccionesDeZonas(
                        Guid.NewGuid(),
                        "Restriccion 4",
                        "11,12,13,14,15,16,17,18",
                        "11,12,13,14,15,16,17,18",
                        "Los fisioteapeutas ubicados en manos pueden programar en cualquier mano"
                    )
                );

                _context.SaveChanges();
            }
        }

        public async Task AddRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            ValidationHelper.ValidateEntity(restriccionesDeZonas);

            await _context.RestriccionesDeZonas.AddAsync(restriccionesDeZonas);
        }

        public async Task DeleteRestriccionesDeZonas(Guid id)
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.FindAsync(id);

            if (restriccionesDeZonas == null)
            {
                throw new ArgumentException("La restriccion no existe");
            }

            _context.RestriccionesDeZonas.Remove(restriccionesDeZonas);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RestriccionesDeZonas>> GetRestriccionesDeZonas()
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.ToListAsync();

            if (restriccionesDeZonas == null)
            {
                throw new ArgumentException("No hay restricciones registradas");
            }

            return restriccionesDeZonas;
        }

        public async Task<RestriccionesDeZonas?> GetRestriccionesDeZonasById(Guid id)
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.FindAsync(id);

            if (restriccionesDeZonas == null)
            {
                throw new ArgumentException("La restriccion no existe");
            }

            return restriccionesDeZonas;
        }

        public async Task UpdateRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            var restriccionesDeZonasToUpdate = await _context.RestriccionesDeZonas.FindAsync(restriccionesDeZonas.RestriccionesDeZonasId);

            if (restriccionesDeZonasToUpdate == null)
            {
                throw new ArgumentException("La restriccion no existe");
            }

            restriccionesDeZonasToUpdate.SetNombre(restriccionesDeZonas.Nombre);
            restriccionesDeZonasToUpdate.SetFromRooms(restriccionesDeZonas.FromRooms);
            restriccionesDeZonasToUpdate.SetToRooms(restriccionesDeZonas.ToRooms);
            restriccionesDeZonasToUpdate.SetRegla(restriccionesDeZonas.Regla);

            await _context.SaveChangesAsync();
        }
    }

}
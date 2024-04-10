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
        }

        public async Task AddRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            ValidationHelper.ValidateEntity(restriccionesDeZonas);

            await _context.RestriccionesDeZonas.AddAsync(restriccionesDeZonas);
        }

        public async Task DeleteRestriccionesDeZonas(Guid id)
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.FindAsync(id);

            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("La restriccion no existe");
            }

            _context.RestriccionesDeZonas.Remove(restriccionesDeZonas);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RestriccionesDeZonas>> GetRestriccionesDeZonas()
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.ToListAsync();

            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("No hay restricciones registradas");
            }

            return restriccionesDeZonas;
        }

        public async Task<RestriccionesDeZonas?> GetRestriccionesDeZonasById(Guid id)
        {
            var restriccionesDeZonas = await _context.RestriccionesDeZonas.FindAsync(id);

            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("La restriccion no existe");
            }

            return restriccionesDeZonas;
        }

        public async Task UpdateRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            var restriccionesDeZonasToUpdate = await _context.RestriccionesDeZonas.FindAsync(restriccionesDeZonas.RestriccionesDeZonasId);

            if(restriccionesDeZonasToUpdate == null)
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
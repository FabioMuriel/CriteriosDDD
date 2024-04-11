using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplication.services
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository _zonaRepository;

        public ZonaService(IZonaRepository zonaRepository)
        {
            _zonaRepository = zonaRepository;
        }

        public async Task AddZona(Zona zona)
        {
            if (zona == null)
            {
                throw new ArgumentException("La zona no puede ser nula");
            }

            await _zonaRepository.AddZona(zona);
        }

        public async Task DeleteZona(Guid id)
        {
            Zona? zona = await _zonaRepository.GetZonaById(id);

            if (zona == null)
            {
                throw new ArgumentException("La zona no existe");
            }

            await _zonaRepository.DeleteZona(id);
        }

        public async Task<Zona?> GetZonaById(Guid id)
        {
            Zona? zona = await _zonaRepository.GetZonaById(id);

            if (zona == null)
            {
                throw new ArgumentException("La zona no existe");
            }

            return zona;
        }

        public async Task<IEnumerable<Zona>> GetZonas()
        {
            return await _zonaRepository.GetZonas();
        }

        public async Task UpdateZona(Zona zona)
        {
            if (zona == null)
            {
                throw new ArgumentException("La zona no puede ser nula");
            }

            await _zonaRepository.UpdateZona(zona);
        }
    }
}
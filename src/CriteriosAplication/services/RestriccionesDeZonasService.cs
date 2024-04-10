using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services{

    public class RestriccionesDeZonasService : IRestriccionesDeZonasService
    {

        private readonly IRestriccionesDeZonasRepository _restriccionesDeZonasRepository;

        public RestriccionesDeZonasService(IRestriccionesDeZonasRepository restriccionesDeZonasRepository)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
        }

        public async Task AddRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("Las restricciones de zonas no pueden ser nulas");
            }

            await _restriccionesDeZonasRepository.AddRestriccionesDeZonas(restriccionesDeZonas);

        }

        public async Task DeleteRestriccionesDeZonas(Guid id)
        {
            RestriccionesDeZonas? restriccionesDeZonas = await _restriccionesDeZonasRepository.GetRestriccionesDeZonasById(id);

            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("Las restricciones de zonas no existen");
            }

            await _restriccionesDeZonasRepository.DeleteRestriccionesDeZonas(id);
        }

        public async Task<IEnumerable<RestriccionesDeZonas>> GetRestriccionesDeZonas()
        {
            return await _restriccionesDeZonasRepository.GetRestriccionesDeZonas();
        }

        public async Task<RestriccionesDeZonas?> GetRestriccionesDeZonasById(Guid id)
        {
            RestriccionesDeZonas? restriccionesDeZonas = await _restriccionesDeZonasRepository.GetRestriccionesDeZonasById(id);

            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("Las restricciones de zonas no existen");
            }

            return restriccionesDeZonas;
        }

        public async Task UpdateRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas)
        {
            if(restriccionesDeZonas == null)
            {
                throw new ArgumentException("Las restricciones de zonas no pueden ser nulas");
            }

            await _restriccionesDeZonasRepository.UpdateRestriccionesDeZonas(restriccionesDeZonas);
        }
    }

}
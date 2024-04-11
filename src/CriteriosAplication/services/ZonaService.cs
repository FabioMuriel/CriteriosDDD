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

        public async Task<IGenericResponse> AddZona(Zona zona)
        {
            if (zona == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "La zona no puede ser nula"
                };
            }

            await _zonaRepository.AddZona(zona);

            return new GenericResponse
            {
                Success = true,
                Message = "Zona creada correctamente"
            };
            
        }

        public async Task<IGenericResponse> DeleteZona(Guid id)
        {
            Zona? zona = await _zonaRepository.GetZonaById(id);

            if (zona == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "No se encontro la zona"
                };
            }

            await _zonaRepository.DeleteZona(id);

            return new GenericResponse
            {
                Success = true,
                Message = "Zona eliminada correctamente"
            };
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

        public async Task<IGenericResponse> UpdateZona(Zona zona)
        {
            if (zona == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "La zona no puede ser nula"
                };
            }

            await _zonaRepository.UpdateZona(zona);

            return new GenericResponse
            {
                Success = true,
                Message = "Zona actualizada correctamente"
            };
        }

        public class GenericResponse : IGenericResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    }
}
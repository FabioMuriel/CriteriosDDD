using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services
{

    class FisioterapeutaService : IFisioterapeutaService
    {

        private readonly IFisioterapeutaRepository _fisioterapeutaRepository;

        public FisioterapeutaService(IFisioterapeutaRepository fisioterapeutaRepository)
        {
            _fisioterapeutaRepository = fisioterapeutaRepository;
        }

        public async Task<IGenericResponse> AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            if (fisioterapeuta == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "El fisioterapeuta no puede ser nulo"
                };
            }

            if (fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || (fisioterapeuta.Rango != 10 && fisioterapeuta.Rango != 20 && fisioterapeuta.Rango != 30))
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "El rango del fisioterapeuta no es valido"
                };
            }

            await _fisioterapeutaRepository.AddFisioterapeuta(fisioterapeuta);

            return new GenericResponse
            {
                Success = true,
                Message = "Fisioterapeuta creado correctamente"
            };

        }

        public async Task<IGenericResponse> DeleteFisioterapeuta(Guid id)
        {
            Fisioterapeuta? fisioterapeuta = await _fisioterapeutaRepository.GetFisioterapeutaById(id);

            if (fisioterapeuta == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "El fisioterapeuta no existe"
                };
            }

            await _fisioterapeutaRepository.DeleteFisioterapeuta(id);

            return new GenericResponse
            {
                Success = true,
                Message = "Fisioterapeuta eliminado correctamente"
            };

        }

        public async Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta()
        {
            return await _fisioterapeutaRepository.GetFisioterapeuta();
        }

        public async Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id)
        {
            Fisioterapeuta? fisioterapeuta = await _fisioterapeutaRepository.GetFisioterapeutaById(id);

            if (fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            return fisioterapeuta;
        }

        public async Task<IGenericResponse> UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            if (fisioterapeuta == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "El fisioterapeuta no puede ser nulo"
                };
            }

            if (fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || fisioterapeuta.Rango != 10 || fisioterapeuta.Rango != 20 || fisioterapeuta.Rango != 30)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "El rango del fisioterapeuta no es valido"
                };
            }

            await _fisioterapeutaRepository.UpdateFisioterapeuta(fisioterapeuta);

            return new GenericResponse
            {
                Success = true,
                Message = "Fisioterapeuta actualizado correctamente"
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
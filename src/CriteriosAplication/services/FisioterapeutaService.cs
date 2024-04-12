using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services
{

    public class FisioterapeutaService : IFisioterapeutaService
    {
        private readonly IFisioterapeutaRepository _fisioterapeutaRepository;

        public FisioterapeutaService(IFisioterapeutaRepository fisioterapeutaRepository)
        {
            _fisioterapeutaRepository = fisioterapeutaRepository;
        }

        public async Task<IGenericResponse> AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            bool _success = true;
            string _message = "Fisioterapeuta creado correctamente";

            if (fisioterapeuta == null)
            {
                _success = false;
                _message = "El fisioterapeuta no puede ser nulo";
            }

            if (fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || (fisioterapeuta.Rango != 10 && fisioterapeuta.Rango != 20 && fisioterapeuta.Rango != 30))
            {
                _success = false;
                _message = "El rango del fisioterapeuta no es valido";
            }

            await _fisioterapeutaRepository.AddFisioterapeuta(fisioterapeuta);

            return new GenericResponse
            {
                Success = _success,
                Message = _message
            };

        }

        public async Task<IGenericResponse> DeleteFisioterapeuta(Guid id)
        {
            bool _success = true;
            string _message = "Fisioterapeuta eliminado correctamente";
            Fisioterapeuta? fisioterapeuta = await _fisioterapeutaRepository.GetFisioterapeutaById(id);

            if (fisioterapeuta == null)
            {
                _success = false;
                _message = "El fisioterapeuta no existe";
            }

            await _fisioterapeutaRepository.DeleteFisioterapeuta(id);

            return new GenericResponse
            {
                Success = _success,
                Message = _message
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
            bool _success = true;
            string _message = "Fisioterapeuta actualizado correctamente";

            if (fisioterapeuta == null)
            {
                _success = false;
                _message = "El fisioterapeuta no puede ser nulo";
            }

            if (fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || fisioterapeuta.Rango != 10 || fisioterapeuta.Rango != 20 || fisioterapeuta.Rango != 30)
            {
                _success = false;
                _message = "El rango del fisioterapeuta no es valido";
            }

            await _fisioterapeutaRepository.UpdateFisioterapeuta(fisioterapeuta);

            return new GenericResponse
            {
                Success = _success,
                Message = _message
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
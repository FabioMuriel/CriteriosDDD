using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.Servicios;

namespace CriteriosAplicaion.Services
{
    public class SchedService : ISchedService
    {
        private readonly ISchedRepository _schedRepository;
        private readonly IPosicionDeAgendamientoValido _posicionDeAgendamientoValido;
        private readonly IValidadorDeRestriccionesDeZonas _validadorDeRestriccionesDeZonas;

        public SchedService(ISchedRepository schedRepository, IPosicionDeAgendamientoValido posicionDeAgendamientoValido, IValidadorDeRestriccionesDeZonas validadorDeRestriccionesDeZonas)
        {
            _schedRepository = schedRepository;
            _posicionDeAgendamientoValido = posicionDeAgendamientoValido;
            _validadorDeRestriccionesDeZonas = validadorDeRestriccionesDeZonas;
        }

        public async Task<IGenericResponse> AddSched(Sched sched)
        {
            var validationError = await ValidarDisponibilidadDeEspacio(sched.RoomId, sched.FisioterapeutaId, sched.Hora, sched.Fecha);

            if (validationError.Any())
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "Error al crear la cita.",
                    Errors = validationError
                };
            }
           
            if (sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.AddSched(sched);

            return new GenericResponse
            {
                Success = true,
                Message = "Cita creada correctamente."
            };
        }

        public async Task<IGenericResponse> DeleteSched(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if (sched == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "No se encontro la cita"
                };
            }

            await _schedRepository.DeleteSched(id);

            return new GenericResponse
            {
                Success = true,
                Message = "Cita eliminada correctamente"
            };
        }

        public async Task<IEnumerable<Sched>> GetSched()
        {
            return await _schedRepository.GetSched();
        }

        public async Task<Sched?> GetSchedById(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if (sched == null)
            {
                throw new ArgumentException("El sched no existe");
            }

            return sched;
        }

        public async Task<IGenericResponse> UpdateSched(Sched sched)
        {
            var validationError = await ValidarDisponibilidadDeEspacio(sched.RoomId, sched.FisioterapeutaId, sched.Hora, sched.Fecha);

            if (validationError.Any())
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "Error al actualizar la cita.",
                    Errors = validationError
                };
            }

            if (sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.UpdateSched(sched);

            return new GenericResponse
            {
                Success = true,
                Message = "Cita actualizada correctamente."
            };

        }

        //TODO: Verificar si es necesario mover este metodo a un servicio de validacion
        private async Task<IEnumerable<string>> ValidarDisponibilidadDeEspacio(Guid RoomId, Guid FisioterapeutaId, int Hora, string Fecha)
        {

            List<string> errores = new List<string>();

            var espacioDisponible = await _posicionDeAgendamientoValido.ValidarPosicion(new PosicionDeAgendamientoValidoRequest
            {
                RoomId = RoomId,
                FisioterapeutaId = FisioterapeutaId,
                Hora = Hora,
                Fecha = Fecha
            });

            var criterioDeEspacio = await _validadorDeRestriccionesDeZonas.ValidarRestricciones(
                new ValidadorDeRestriccionesDeZonasRequest
                {
                    RoomId = RoomId,
                    FisioterapeutaId = FisioterapeutaId,
                    Hora = Hora,
                    Fecha = Fecha
                }
            );

            if (espacioDisponible.EspacioDisponible == false)
            {
                errores.Add(espacioDisponible.Message);
            }

            if(criterioDeEspacio.IsValid == false)
            {
                errores.Add(criterioDeEspacio.Mensaje);
            }

            return errores;
        }

        public class GenericResponse : IGenericResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    }
}
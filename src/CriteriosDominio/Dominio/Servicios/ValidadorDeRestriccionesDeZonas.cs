using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;

namespace CriteriosDominio.Dominio.Servicios
{
    public class ValidadorDeRestriccionesDeZonas : IValidadorDeRestriccionesDeZonas
    {
        private readonly IRestriccionesDeZonasRepository _restriccionesDeZonasRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly ISchedRepository _schedRepository;
        private readonly IFisioterapeuta _fisioterapeuta;

        public ValidadorDeRestriccionesDeZonas(IRestriccionesDeZonasRepository restriccionesDeZonasRepository, IRoomsRepository roomsRepository, ISchedRepository schedRepository, IFisioterapeuta fisioterapeuta)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
            _roomsRepository = roomsRepository;
            _schedRepository = schedRepository;
            _fisioterapeuta = fisioterapeuta;
        }

        public IValidadorDeRestriccionesDeZonasResult ValidarRestricciones(IRestriccionesDeZonasRequest request)
        {

            var validations = ValidateService(request);
            if (validations.Any())
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = false,
                    errores = validations
                };
            }

            var fisioterapeuta = _fisioterapeuta.GetFisioterapeutaById(request.fisioterapeutaId);
            if (fisioterapeuta.Rango == 30)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    isValid = true,
                    mensaje = "Agendamiento valido",
                    Success = true
                };
            }

            var sched = _schedRepository.GetSched();
            var currentePositionRoom = _roomsRepository.GetRoomsById(request.roomId).ColumnOrder;
            var ultimaPosicion = sched.Find(x => x.FisioterapeutaId == request.fisioterapeutaId)!.RoomId;
            var lastPositionRoom = _roomsRepository.GetRoomsById(ultimaPosicion).ColumnOrder;
            var restricciones = _restriccionesDeZonasRepository.GetRestriccionesDeZonas();
            bool isValidAgendamiento = false;
            string mensaje = string.Empty;

            foreach (var restriccion in restricciones)
            {
                if (restriccion.FromRooms.Split('-')[lastPositionRoom] == "1" && restriccion.ToRooms.Split('-')[currentePositionRoom] == "1")
                {
                    isValidAgendamiento = true;
                    break;
                }
                else
                {
                    mensaje = restriccion.Nombre;
                    break;
                }
            }

            return new ValidadorDeRestriccionesDeZonasResult
            {
                isValid = isValidAgendamiento,
                mensaje = mensaje == string.Empty ? "Agendamiento valido" : mensaje,
                Success = true
            };
        }

        public List<String> ValidateService(IRestriccionesDeZonasRequest request)
        {
            List<String> errores = new List<String>();

            if (request is null)
            {
                errores.Add("El Request no puede ser nulo");
            }
            else
            {
                if (request.roomId == 0)
                {
                    errores.Add("El roomId no puede ser 0");
                }
                if (request.fisioterapeutaId == 0)
                {
                    errores.Add("El fisioterapeutaId no puede ser 0");
                }
                if (request.hora < 6)
                {
                    errores.Add("La hora no puede ser menor a 6");
                }
                if (request.fecha == DateTime.MinValue)
                {
                    errores.Add("La fecha no puede ser 0");
                }

                List<Rooms> fisioterapeutas = _roomsRepository.GetRooms();

                if (fisioterapeutas.Find(x => x.RoomId == request.roomId) == null)
                {
                    errores.Add("El room no existe");
                }
            }

            return errores;

        }
    }

    public class ValidadorDeRestriccionesDeZonasResult : IValidadorDeRestriccionesDeZonasResult
    {
        public bool isValid { get; set; }
        public string mensaje { get; set; } = string.Empty;
        public bool Success { get; set; }
        public List<string>? errores { get; set; }
    }

    public class ValidadorDeRestriccionesDeZonasRequest : IRestriccionesDeZonasRequest
    {
        public int roomId { get; set; }
        public int fisioterapeutaId { get; set; }
        public int hora { get; set; }
        public DateTime fecha { get; set; }
    }
}
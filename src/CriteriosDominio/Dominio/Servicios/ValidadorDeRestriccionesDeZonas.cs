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

        public ValidadorDeRestriccionesDeZonas(IRestriccionesDeZonasRepository restriccionesDeZonasRepository, IRoomsRepository roomsRepository, ISchedRepository schedRepository)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
            _roomsRepository = roomsRepository;
            _schedRepository = schedRepository;
        }

        public IValidadorDeRestriccionesDeZonasResult Validar(IRestriccionesDeZonasRequest request)
        {
            var room = _roomsRepository.GetRooms();
            var sched = _schedRepository.GetSched();

            var currentePositionRoom = room.Find(x => x.RoomId == request.roomId)!.ColumnOrder;
            var ultimaPosicion = sched.Find(x => x.FisioterapeutaId == request.fisioterapeutaId)!.RoomId;
            var lastPositionRoom = room.Find(x => x.RoomId == ultimaPosicion)!.ColumnOrder;
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
                }
            }

            return new ValidadorDeRestriccionesDeZonasResult
            {
                isValid = isValidAgendamiento,
                mensaje = mensaje == string.Empty ? "Agendamiento valido" : mensaje
            };
        }
    }

    public class ValidadorDeRestriccionesDeZonasResult : IValidadorDeRestriccionesDeZonasResult
    {
        public bool isValid { get; set; }
        public string mensaje { get; set; } = string.Empty;
        public bool Success { get; set; }
    }

    public class ValidadorDeRestriccionesDeZonasRequest : IRestriccionesDeZonasRequest
    {
        public int roomId { get; set; }
        public int fisioterapeutaId { get; set; }
        public int hora { get; set; }
        public DateTime fecha { get; set; }
    }
}
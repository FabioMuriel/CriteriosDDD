using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;

namespace CriteriosDominio.Dominio.Servicios
{
    public class ValidadorDeRestriccionesDeZonas
    {
        private readonly IRestriccionesDeZonasRepository _restriccionesDeZonasRepository;
        private readonly IRoomsRepository _roomsRepository;

        public ValidadorDeRestriccionesDeZonas(IRestriccionesDeZonasRepository restriccionesDeZonasRepository, IRoomsRepository roomsRepository)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
            _roomsRepository = roomsRepository;
        }

        public bool Validar(Sched sched, List<Sched> todasLasCitas)
        {

            var room = _roomsRepository.GetRooms();
            var todasLasCitasDeLaSala = todasLasCitas;
            var currentePositionRoom = room.Find(x => x.RoomId == sched.RoomId).ColumnOrder;
            var ultimaPosicion = todasLasCitasDeLaSala.Find(x => x.FisioterapeutaId == sched.FisioterapeutaId).RoomId;
            var lastPositionRoom = room.Find(x => x.RoomId == ultimaPosicion).ColumnOrder;

            var restricciones = _restriccionesDeZonasRepository.GetRestriccionesDeZonas();
            bool isValidAgendamiento = false;
            string mensaje;

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

            return isValidAgendamiento;

        }
    }
}
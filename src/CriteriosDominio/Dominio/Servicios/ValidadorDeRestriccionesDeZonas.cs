using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.Servicios
{
    public class ValidadorDeRestriccionesDeZonas : IValidadorDeRestriccionesDeZonas
    {
        private readonly IRestriccionesDeZonasRepository _restriccionesDeZonasRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly ISchedRepository _schedRepository;
        private readonly IFisioterapeutaRepository _fisioterapeuta;

        private readonly IPosicionDeAgendamientoValido _posicionDeAgendamientoValido;

        public ValidadorDeRestriccionesDeZonas(IRestriccionesDeZonasRepository restriccionesDeZonasRepository, IRoomsRepository roomsRepository, ISchedRepository schedRepository, IFisioterapeutaRepository fisioterapeuta, IPosicionDeAgendamientoValido posicionDeAgendamientoValido)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
            _roomsRepository = roomsRepository;
            _schedRepository = schedRepository;
            _fisioterapeuta = fisioterapeuta;
            _posicionDeAgendamientoValido = posicionDeAgendamientoValido;
        }

        public async Task<IValidadorDeRestriccionesDeZonasResult> ValidarRestricciones(IRestriccionesDeZonasRequest request)
        {

            var espacioDisponible = await _posicionDeAgendamientoValido.ValidarPosicion(new PosicionDeAgendamientoValidoRequest
            {
                RoomId = request.roomId,
                FisioterapeutaId = request.fisioterapeutaId,
                Hora = request.hora,
                Fecha = request.fecha
            });

            if(espacioDisponible.EspacioDisponible == false)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = true,
                    isValid = false,
                    mensaje = "El espacio no esta disponible"
                };
            }

            var Validations = ValidateService(request);
            var roomsTask = _roomsRepository.GetRooms();
            var restriccionesTask = _restriccionesDeZonasRepository.GetRestriccionesDeZonas();
            var schedsTask = _schedRepository.GetSched();
            bool fisioIsMaster = await FisioIsMaster(request.fisioterapeutaId);

            if (Validations.Any())
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = false,
                    errores = Validations
                };
            }

            if (fisioIsMaster)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = true,
                    isValid = true
                };
            }

            await Task.WhenAll(roomsTask, restriccionesTask, schedsTask);

            var rooms = await roomsTask;
            var restricciones = await restriccionesTask;
            var scheds = await schedsTask;

            var requestLastPositionsFisio = scheds.Where(s => s.FisioterapeutaId == request.fisioterapeutaId && s.Fecha == request.fecha && s.Hora == request.hora);

            var posicionDeseada = rooms.First(r => r.RoomId == request.roomId);

            if (requestLastPositionsFisio is null)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = true,
                    isValid = true,
                    mensaje = "El fisioterapeuta no tiene restricciones"
                };
            }

            List<bool> agendamientoValido = new List<bool>();
            string descriptionRestriction = string.Empty;

            foreach (var lastPosition in requestLastPositionsFisio)
            {

                int restriccionPrescisa = 0;

                var areaRoomLastPosition = rooms.First(r => r.RoomId == lastPosition.RoomId);

                if (areaRoomLastPosition.ZonaId == posicionDeseada.ZonaId)
                {
                    agendamientoValido.Add(true);
                    continue;
                }

                restriccionPrescisa = restricciones
                    .Where(
                        r => r.FromRooms.Split(',').Contains(areaRoomLastPosition.RoomId.ToString()) &&
                        r.ToRooms.Split(',').Contains(posicionDeseada.RoomId.ToString())
                    ).Count();

                if (restriccionPrescisa > 0)
                {
                    agendamientoValido.Add(true);
                    continue;
                }

                foreach (var restriccion in restricciones)
                {
                    List<string> fromRooms = restriccion.FromRooms.Split(',').ToList();

                    if (fromRooms.Contains(areaRoomLastPosition.RoomId.ToString()))
                    {
                        List<string> toRooms = restriccion.ToRooms.Split(',').ToList();

                        if (toRooms.Contains(posicionDeseada.RoomId.ToString()))
                        {
                            agendamientoValido.Add(true);
                            break;
                        }
                        else
                        {
                            agendamientoValido.Add(false);
                            descriptionRestriction = restriccion.Regla;
                            break;
                        }

                    }

                }

            }

            bool isValid = agendamientoValido.All(a => a);

            return new ValidadorDeRestriccionesDeZonasResult
            {
                Success = true,
                isValid = isValid,
                mensaje = "El fisioterapeuta no tiene restricciones"
            };
        }

        private async Task<bool> FisioIsMaster(Guid fisioterapeutaId)
        {
            Fisioterapeuta? fisio = await _fisioterapeuta.GetFisioterapeutaById(fisioterapeutaId);

            return fisio?.Rango == 30;
        }

        public List<string> ValidateService(IRestriccionesDeZonasRequest request)
        {
            List<string> errores = new List<string>(); ;

            if (request is null)
            {
                errores.Add("El Request no puede ser nulo");
            }
            else
            {
                if (request.roomId == Guid.Empty)
                {
                    errores.Add("El roomId no puede ser 0");
                }
                if (string.IsNullOrEmpty(request.fisioterapeutaId.ToString()))
                {
                    errores.Add("El fisioterapeutaId no puede ser 0");
                }
                if (request.hora < 6 || request.hora > 18)
                {
                    errores.Add("La hora no puede ser menor a 6 ni mayor a 18");
                }
                if (request.fecha == DateTime.MinValue)
                {
                    errores.Add("La fecha no puede ser 0");
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
        public Guid roomId { get; set; }
        public Guid fisioterapeutaId { get; set; }
        public int hora { get; set; }
        public DateTime fecha { get; set; }
    }
}
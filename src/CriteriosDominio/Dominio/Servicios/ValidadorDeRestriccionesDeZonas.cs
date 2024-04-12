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

        public ValidadorDeRestriccionesDeZonas(IRestriccionesDeZonasRepository restriccionesDeZonasRepository, IRoomsRepository roomsRepository, ISchedRepository schedRepository, IFisioterapeutaRepository fisioterapeuta)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
            _roomsRepository = roomsRepository;
            _schedRepository = schedRepository;
            _fisioterapeuta = fisioterapeuta;
        }

        public async Task<IValidadorDeRestriccionesDeZonasResult> ValidarRestricciones(IRestriccionesDeZonasRequest request)
        {
            var Validations = ValidateService(request);

            if (Validations.Any())
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = false,
                    Errores = Validations
                };
            }

            var roomsTask = _roomsRepository.GetRooms();
            var restriccionesTask = _restriccionesDeZonasRepository.GetRestriccionesDeZonas();
            var schedsTask = _schedRepository.GetSched();
            bool fisioIsMaster = await FisioIsMaster(request.FisioterapeutaId);

            if (fisioIsMaster)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = true,
                    IsValid = true
                };
            }

            await Task.WhenAll(roomsTask, restriccionesTask, schedsTask);

            var rooms = await roomsTask;
            var restricciones = await restriccionesTask;
            var scheds = await schedsTask;

            var requestLastPositionsFisio = scheds
                .Where(s => s.FisioterapeutaId == request.FisioterapeutaId &&
                s.Fecha == request.Fecha &&
                s.Hora == request.Hora
            ).ToList();

            var posicionDeseada = rooms.First(r => r.RoomId == request.RoomId);

            if (requestLastPositionsFisio is null)
            {
                return new ValidadorDeRestriccionesDeZonasResult
                {
                    Success = true,
                    IsValid = true,
                    Mensaje = "El fisioterapeuta no tiene restricciones"
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
                        r => r.FromRooms.Split(',').Contains(areaRoomLastPosition.ColumnOrder.ToString()) &&
                        r.ToRooms.Split(',').Contains(posicionDeseada.ColumnOrder.ToString())
                    ).Count();

                if (restriccionPrescisa > 0)
                {
                    agendamientoValido.Add(true);
                    continue;
                }

                foreach (var restriccion in restricciones)
                {
                    List<string> fromRooms = restriccion.FromRooms.Split(',').ToList();

                    if (fromRooms.Contains(areaRoomLastPosition.ColumnOrder.ToString()))
                    {
                        List<string> toRooms = restriccion.ToRooms.Split(',').ToList();

                        if (toRooms.Contains(posicionDeseada.ColumnOrder.ToString()))
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
                IsValid = isValid,
                Mensaje = descriptionRestriction
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
                if (request.RoomId == Guid.Empty)
                {
                    errores.Add("El roomId no puede ser nulo");
                }
                if (request.FisioterapeutaId == Guid.Empty)
                {
                    errores.Add("El fisioterapeutaId no puede ser nulo");
                }
                if (request.Hora < 6 || request.Hora > 18)
                {
                    errores.Add("La hora no puede ser menor a 6 ni mayor a 18");
                }
                if (string.IsNullOrEmpty(request.Fecha) || request.Fecha == "0" || request.Fecha == "01/01/0001")
                {
                    errores.Add("La fecha es invalida");
                }
            }

            return errores;

        }

    }

    public class ValidadorDeRestriccionesDeZonasResult : IValidadorDeRestriccionesDeZonasResult
    {
        public bool IsValid { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public bool Success { get; set; }
        public IEnumerable<string>? Errores { get; set; }
    }

    public class ValidadorDeRestriccionesDeZonasRequest : IRestriccionesDeZonasRequest
    {
        public Guid RoomId { get; set; }
        public Guid FisioterapeutaId { get; set; }
        public int Hora { get; set; }
        public string Fecha { get; set; }
    }
}
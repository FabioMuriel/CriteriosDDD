using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.Servicios
{

    public class PosicionDeAgendamientoValido : IPosicionDeAgendamientoValido
    {

        private readonly ISchedRepository _schedRepository;

        public PosicionDeAgendamientoValido(ISchedRepository schedRepository)
        {
            _schedRepository = schedRepository;
        }

        public async Task<IPosicionDeAgendamientoValidoResult> ValidarPosicion(IPosicionDeAgendamientoValidoRequest request)
        {
            var scheds = await _schedRepository.GetSched();
            
            var espacioOcupado = scheds
                .Where(s => s.RoomId == request.RoomId && s.FisioterapeutaId == request.FisioterapeutaId && s.Fecha == request.Fecha && s.Hora == request.Hora)
                .Any();

            bool espacio = espacioOcupado ? false : true;

            return new PosicionDeAgendamientoValidoResult
            {
                Success = true,
                EspacioDisponible = espacio
            };
        }
    }

    public class PosicionDeAgendamientoValidoResult : IPosicionDeAgendamientoValidoResult
    {
        public bool Success { get; set; }
        public bool EspacioDisponible { get; set; }
    }

    public class PosicionDeAgendamientoValidoRequest : IPosicionDeAgendamientoValidoRequest
    {
        public Guid RoomId { get; set; }
        public Guid FisioterapeutaId { get; set; }
        public int Hora { get; set; }
        public DateTime Fecha { get; set; }
    }

}
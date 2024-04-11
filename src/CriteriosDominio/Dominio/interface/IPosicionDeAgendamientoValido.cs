namespace CriteriosDominio.Dominio.interfaces
{
    public interface IPosicionDeAgendamientoValido
    {
        Task<IPosicionDeAgendamientoValidoResult> ValidarPosicion(IPosicionDeAgendamientoValidoRequest request);
    }

    public interface IPosicionDeAgendamientoValidoRequest
    {
        Guid RoomId { get; set; }
        Guid FisioterapeutaId { get; set; }
        int Hora { get; set; }
        DateTime Fecha { get; set; }
    }

    public interface IPosicionDeAgendamientoValidoResult
    {
        bool Success { get; set; }
        bool EspacioDisponible { get; set; }
    }
}
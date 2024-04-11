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
        string Fecha { get; set; }
    }

    public interface IPosicionDeAgendamientoValidoResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        bool EspacioDisponible { get; set; }
    }
}
namespace CriteriosDominio.Dominio.interfaces
{
    public interface IValidadorDeRestriccionesDeZonas
    {
        Task<IValidadorDeRestriccionesDeZonasResult> ValidarRestricciones(IRestriccionesDeZonasRequest request);
        List<string> ValidateService(IRestriccionesDeZonasRequest request);

    }

    public interface IValidadorDeRestriccionesDeZonasResult
    {
        bool Success { get; set; }
        bool IsValid { get; set; }
        string Mensaje { get; set; }
        IEnumerable<string>? Errores { get; set; }
    }

    public interface IRestriccionesDeZonasRequest
    {
        Guid RoomId { get; set; }
        Guid FisioterapeutaId { get; set; }
        int Hora { get; set; }
        string Fecha { get; set; }
    }
}
namespace CriteriosDominio.Dominio.interfaces
{
    public interface IValidadorDeRestriccionesDeZonas
    {
        IValidadorDeRestriccionesDeZonasResult ValidarRestricciones(IRestriccionesDeZonasRequest request);
        List<string> ValidateService(IRestriccionesDeZonasRequest request);

    }

    public interface IValidadorDeRestriccionesDeZonasResult
    {
        bool Success { get; set; }
        bool isValid { get; set; }
        string mensaje { get; set; }
    }

    public interface IRestriccionesDeZonasRequest
    {
        int roomId { get; set; }
        Guid fisioterapeutaId { get; set; }
        int hora { get; set; }
        DateTime fecha { get; set; }
    }
}
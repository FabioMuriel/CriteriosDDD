namespace CriteriosDominio.Dominio.interfaces
{
    public interface IValidadorDeRestriccionesDeZonas
    {
        IValidadorDeRestriccionesDeZonasResult Validar(IRestriccionesDeZonasRequest request);
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
        int fisioterapeutaId { get; set; }
        int hora { get; set; }
        DateTime fecha { get; set; }
    }
}
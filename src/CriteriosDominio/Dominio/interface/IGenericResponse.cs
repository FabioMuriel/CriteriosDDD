namespace CriteriosDominio.Dominio.interfaces
{
    public interface IGenericResponse
    {
        bool Success { get; set; }
        string? Message { get; set; }
        IEnumerable<string>? Errors { get; set; }
    }
}   
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IZonaService
    {
        Task<IEnumerable<Zona>> GetZonas();
        Task<Zona?> GetZonaById(Guid id);
        Task<IGenericResponse> AddZona(Zona zona);
        Task<IGenericResponse> UpdateZona(Zona zona);
        Task<IGenericResponse> DeleteZona(Guid id);
    }
}
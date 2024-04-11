using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IZonaService
    {
        Task<IEnumerable<Zona>> GetZonas();
        Task<Zona?> GetZonaById(Guid id);
        Task AddZona(Zona zona);
        Task UpdateZona(Zona zona);
        Task DeleteZona(Guid id);
    }
}
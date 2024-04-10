
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IZonaRepository
    {
        Task<IEnumerable<Zona>> GetZonas();
        Task<Zona?> GetZonaById(int id);
        Task AddZona(Zona zona);
        Task UpdateZona(Zona zona);
        Task DeleteZona(int id);

    }
}
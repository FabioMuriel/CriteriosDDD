using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces{
    public interface IRestriccionesDeZonasService{
        Task<IEnumerable<RestriccionesDeZonas>> GetRestriccionesDeZonas();
        Task<RestriccionesDeZonas?> GetRestriccionesDeZonasById(Guid id);
        Task AddRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas);
        Task DeleteRestriccionesDeZonas(Guid id);
        Task UpdateRestriccionesDeZonas(RestriccionesDeZonas restriccionesDeZonas);
    }
}
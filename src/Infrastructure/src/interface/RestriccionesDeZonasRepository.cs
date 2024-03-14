using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IRestriccionesDeZonasRepository
    {
        List<RestriccionesDeZonas> GetRestriccionesDeZonas();
    }
}
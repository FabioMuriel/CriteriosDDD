using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IRestriccionesDeZonasRepository
    {
        List<RestriccionesDeZonas> GetRestriccionesDeZonas();
    }
}
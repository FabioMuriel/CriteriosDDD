
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IZonaRepository
    {
        List<Zona> GetZonas();
    }
}
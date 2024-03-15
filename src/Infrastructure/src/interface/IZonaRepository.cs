
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IZonaRepository
    {
        List<Zona> GetZonas();
        void AddZona(Zona zona);
        void UpdateZona(Zona zona);
        void DeleteZona(int id);

    }
}
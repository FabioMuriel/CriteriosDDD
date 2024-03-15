using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IFisioterapeuta
    {
        List<Fisioterapeuta> GetFisioterapeuta();
        Fisioterapeuta GetFisioterapeutaById(int id);
        void AddFisioterapeuta(Fisioterapeuta fisioterapeuta);
        void UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta);
        void DeleteFisioterapeuta(int id);
    }
}
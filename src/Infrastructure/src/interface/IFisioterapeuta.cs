using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IFisioterapeuta
    {
        List<Fisioterapeuta> GetFisioterapeuta();
        void AddFisioterapeuta(Fisioterapeuta fisioterapeuta);
        void UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta);
        void DeleteFisioterapeuta(int id);
    }
}
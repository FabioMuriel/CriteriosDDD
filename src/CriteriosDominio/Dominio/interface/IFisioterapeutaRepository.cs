using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IFisioterapeutaRepository
    {
        Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta();
        Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id);
        Task AddFisioterapeuta(Fisioterapeuta fisioterapeuta);
        Task UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta);
        Task DeleteFisioterapeuta(Guid id);
    }
}
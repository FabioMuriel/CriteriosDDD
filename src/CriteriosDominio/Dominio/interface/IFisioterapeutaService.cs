using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IFisioterapeutaService
    {
        Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta();
        Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id);
        Task AddFisioterapeuta(Fisioterapeuta fisioterapeuta);
        Task DeleteFisioterapeuta(Guid id);
        Task UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta);
    }
}
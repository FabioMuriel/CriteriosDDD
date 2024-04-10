using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface ISchedService
    {
        Task<IEnumerable<Sched>> GetSched();
        Task<Sched?> GetSchedById(Guid id);
        Task AddSched(Sched sched);
        Task UpdateSched(Sched sched);
        Task DeleteSched(Guid id);
    }
}
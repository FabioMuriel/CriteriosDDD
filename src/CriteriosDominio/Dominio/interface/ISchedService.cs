using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface ISchedService
    {
        Task<IEnumerable<Sched>> GetSched();
        Task<Sched?> GetSchedById(Guid id);
        Task<IGenericResponse> AddSched(Sched sched);
        Task<IGenericResponse> UpdateSched(Sched sched);
        Task<IGenericResponse> DeleteSched(Guid id);
    }
}
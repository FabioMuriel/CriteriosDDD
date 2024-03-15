using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface ISchedRepository
    {
        List<Sched> GetSched();
        Sched GetSchedById(int id);
        void AddSched(Sched sched);
        void UpdateSched(Sched sched);
        void DeleteSched(int id);
    }
}
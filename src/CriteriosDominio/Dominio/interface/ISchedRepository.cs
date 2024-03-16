using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
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
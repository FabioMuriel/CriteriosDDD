using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface ISchedRepository
    {
        List<Sched> GetSched();
        void AddSched(Sched sched);
    }
}
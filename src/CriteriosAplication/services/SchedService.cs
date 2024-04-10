using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services
{
    public class SchedService : ISchedService
    {
        private readonly ISchedRepository _schedRepository;

        public SchedService(ISchedRepository schedRepository)
        {
            _schedRepository = schedRepository;
        }

        public async Task AddSched(Sched sched)
        {
            if(sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.AddSched(sched);
        }

        public async Task DeleteSched(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if(sched == null)
            {
                throw new ArgumentException("El sched no existe");
            }

            await _schedRepository.DeleteSched(id);
        }

        public async Task<IEnumerable<Sched>> GetSched()
        {
            return await _schedRepository.GetSched();
        }

        public async Task<Sched?> GetSchedById(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if(sched == null)
            {
                throw new ArgumentException("El sched no existe");
            }

            return sched;
        }

        public async Task UpdateSched(Sched sched)
        {
            if(sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.UpdateSched(sched);
        }
    }
}
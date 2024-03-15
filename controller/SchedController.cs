using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedController
    {
        private readonly ISchedRepository _schedRepository;

        public SchedController(ISchedRepository schedRepository)
        {
            _schedRepository = schedRepository;
        }

        [HttpPost]
        public void AddSched(Sched sched)
        {
            _schedRepository.AddSched(sched);
        }

        [HttpGet]
        public List<Sched> GetSched()
        {
            return _schedRepository.GetSched();
        }

        [HttpPut]
        public void UpdateSched(Sched sched)
        {
            _schedRepository.UpdateSched(sched);
        }

        [HttpDelete("{id}")]
        public void DeleteSched(int id)
        {
            _schedRepository.DeleteSched(id);
        }

    }
}
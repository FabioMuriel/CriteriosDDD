using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedController : ControllerBase
    {
        private readonly ISchedRepository _schedRepository;

        public SchedController(ISchedRepository schedRepository)
        {
            _schedRepository = schedRepository;
        }

        [HttpGet]
        public List<Sched> GetSched()
        {
            return _schedRepository.GetSched();
        }

        [HttpGet("{id}")]
        public Sched GetSchedById(int id)
        {
            return _schedRepository.GetSchedById(id);
        }

        [HttpPost]
        public void AddSched(Sched sched)
        {
            _schedRepository.AddSched(sched);
        }

        [HttpPut]
        public void UpdateSched(Sched sched)
        {
            _schedRepository.UpdateSched(sched);
            return Ok("Sched actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public void DeleteSched(int id)
        {
            _schedRepository.DeleteSched(id);
            return Ok("Sched eliminado correctamente");
        }

    }
}
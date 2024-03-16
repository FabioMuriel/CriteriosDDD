using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class SchedController : ControllerBase
    {
        private readonly ISchedRepository _schedRepository;

        public SchedController(ISchedRepository schedRepository)
        {
            _schedRepository = schedRepository;
        }

        [HttpGet]
        public IActionResult GetSched()
        {
            return Ok(_schedRepository.GetSched());
        }

        [HttpGet("{id}")]
        public IActionResult GetSchedById(int id)
        {
            return Ok(_schedRepository.GetSchedById(id));
        }

        [HttpPost]
        public IActionResult AddSched(Sched sched)
        {
            _schedRepository.AddSched(sched);
            return Ok(sched);
        }

        [HttpPut]
        public IActionResult UpdateSched(Sched sched)
        {
            _schedRepository.UpdateSched(sched);
            return Ok("Sched actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSched(int id)
        {
            _schedRepository.DeleteSched(id);
            return Ok("Sched eliminado correctamente");
        }

    }
}
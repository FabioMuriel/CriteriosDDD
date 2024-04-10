using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
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
            if (_schedRepository.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                return Ok(_schedRepository.GetSchedById(id));
            }
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

            if (_schedRepository.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                _schedRepository.DeleteSched(id);
                return Ok("Sched eliminado correctamente");
            }
        }

    }
}
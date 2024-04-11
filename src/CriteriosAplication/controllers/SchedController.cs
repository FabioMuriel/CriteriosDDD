using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class SchedController : ControllerBase
    {
        private readonly ISchedService _schedService;

        public SchedController(ISchedService schedService)
        {
            _schedService = schedService;
        }

        [HttpGet]
        public IActionResult GetSched()
        {
            return Ok(_schedService.GetSched());
        }

        [HttpGet("{id}")]
        public IActionResult GetSchedById(Guid id)
        {
            if (_schedService.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                return Ok(_schedService.GetSchedById(id));
            }
        }

        [HttpPost]
        public IActionResult AddSched(Sched sched)
        {
            _schedService.AddSched(sched);
            return Ok(sched);
        }

        [HttpPut]
        public IActionResult UpdateSched(Sched sched)
        {
            _schedService.UpdateSched(sched);
            return Ok("Sched actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSched(Guid id)
        {

            if (_schedService.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                _schedService.DeleteSched(id);
                return Ok("Sched eliminado correctamente");
            }
        }

    }
}
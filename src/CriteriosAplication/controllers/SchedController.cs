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
        public async Task<IActionResult> GetSched()
        {
            return Ok(await _schedService.GetSched());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedById(Guid id)
        {
            if (await _schedService.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                return Ok(await _schedService.GetSchedById(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSched(Sched sched)
        {
            await _schedService.AddSched(sched);
            return Ok(sched);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSched(Sched sched)
        {
            await _schedService.UpdateSched(sched);
            return Ok("Sched actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSched(Guid id)
        {

            if (await _schedService.GetSchedById(id) == null)
            {
                return BadRequest("No se encontro el sched");
            }
            else
            {
                await _schedService.DeleteSched(id);
                return Ok("Sched eliminado correctamente");
            }
        }

    }
}
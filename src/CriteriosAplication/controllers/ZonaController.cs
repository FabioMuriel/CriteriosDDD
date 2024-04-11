using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        readonly IZonaService _zonaService;
        public ZonaController(IZonaService zonaService)
        {
            _zonaService = zonaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetZonas()
        {
            return Ok(await _zonaService.GetZonas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaById(Guid id)
        {
            if (await _zonaService.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                return Ok(await _zonaService.GetZonaById(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddZona([FromBody] Zona zona)
        {
            await _zonaService.AddZona(zona);
            return Ok(zona);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateZona([FromBody] Zona zona)
        {
            await _zonaService.UpdateZona(zona);
            return Ok("Zona actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(Guid id)
        {
            if (await _zonaService.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                await _zonaService.DeleteZona(id);
                return Ok("Zona eliminada correctamente");
            }
        }
    }
}
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
        public IActionResult GetZonas()
        {
            return Ok(_zonaService.GetZonas());
        }

        [HttpGet("{id}")]
        public IActionResult GetZonaById(Guid id)
        {
            if (_zonaService.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                return Ok(_zonaService.GetZonaById(id));
            }
        }

        [HttpPost]
        public IActionResult AddZona([FromBody] Zona zona)
        {
            _zonaService.AddZona(zona);
            return Ok(zona);
        }

        [HttpPut]
        public IActionResult UpdateZona([FromBody] Zona zona)
        {
            _zonaService.UpdateZona(zona);
            return Ok("Zona actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZona(Guid id)
        {
            if (_zonaService.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                _zonaService.DeleteZona(id);
                return Ok("Zona eliminada correctamente");
            }
        }
    }
}
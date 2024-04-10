using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        readonly IZonaRepository _zonaRepository;
        public ZonaController(IZonaRepository zonaRepository)
        {
            _zonaRepository = zonaRepository;
        }
        [HttpGet]
        public IActionResult GetZonas()
        {
            return Ok(_zonaRepository.GetZonas());
        }

        [HttpGet("{id}")]
        public IActionResult GetZonaById(int id)
        {
            if (_zonaRepository.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                return Ok(_zonaRepository.GetZonaById(id));
            }
        }

        [HttpPost]
        public IActionResult AddZona([FromBody] Zona zona)
        {
            _zonaRepository.AddZona(zona);
            return Ok(zona);
        }

        [HttpPut]
        public IActionResult UpdateZona([FromBody] Zona zona)
        {
            _zonaRepository.UpdateZona(zona);
            return Ok("Zona actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZona(int id)
        {
            if (_zonaRepository.GetZonaById(id) == null)
            {
                return BadRequest("No se encontro la zona");
            }
            else
            {
                _zonaRepository.DeleteZona(id);
                return Ok("Zona eliminada correctamente");
            }
        }
    }
}
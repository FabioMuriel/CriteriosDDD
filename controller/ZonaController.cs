using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
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

        [HttpPost]
        public IActionResult AddZona([FromBody] Zona zona)
        {
            _zonaRepository.AddZona(zona);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateZona([FromBody] Zona zona)
        {
            _zonaRepository.UpdateZona(zona);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZona(int id)
        {
            _zonaRepository.DeleteZona(id);
            return Ok();
        }
    }
}
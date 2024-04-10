using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class FisioterapeutaController : ControllerBase
    {
        readonly IFisioterapeutaService _IFisioterapeuta;

        public FisioterapeutaController(IFisioterapeutaService IFisioterapeuta)
        {
            _IFisioterapeuta = IFisioterapeuta;
        }

        [HttpGet]
        public IActionResult GetFisioterapeuta()
        {
            return Ok(_IFisioterapeuta.GetFisioterapeuta());
        }

        [HttpGet("{id}")]
        public IActionResult GetFisioterapeutaById(Guid id)
        {
            var fisioterapeuta = _IFisioterapeuta.GetFisioterapeutaById(id);
            if (fisioterapeuta == null)
            {
                return BadRequest("No se encontró el fisioterapeuta");
            }
            else
            {
                return Ok(fisioterapeuta);
            }
        }

        [HttpPost]
        public IActionResult AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            _IFisioterapeuta.AddFisioterapeuta(fisioterapeuta);
            return Ok(fisioterapeuta);
        }

        [HttpPut]
        public IActionResult UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
        _IFisioterapeuta.UpdateFisioterapeuta(fisioterapeuta);
            return Ok("Fisioterapeuta actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFisioterapeuta(Guid id)
        {

            if (_IFisioterapeuta.GetFisioterapeutaById(id) == null)
            {
                return BadRequest("No se encontro el fisioterapeuta");
            }
            else
            {
                _IFisioterapeuta.DeleteFisioterapeuta(id);
                return Ok("Fisioterapeuta eliminado correctamente");
            }
        }

    }
}
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]
    public class FisioterapeutaController : ControllerBase
    {
        readonly IFisioterapeuta _IFisioterapeuta;

        public FisioterapeutaController(IFisioterapeuta IFisioterapeuta)
        {
            _IFisioterapeuta = IFisioterapeuta;
        }

        [HttpGet]
        public IActionResult GetFisioterapeuta()
        {
            return Ok(_IFisioterapeuta.GetFisioterapeuta());
        }

        [HttpGet("{id}")]
        public IActionResult GetFisioterapeutaById(int id)
        {
            if (_IFisioterapeuta.GetFisioterapeutaById(id) == null)
            {
                return BadRequest("No se encontro el fisioterapeuta");
            }
            else
            {
                return Ok(_IFisioterapeuta.GetFisioterapeutaById(id));
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
        public IActionResult DeleteFisioterapeuta(int id)
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
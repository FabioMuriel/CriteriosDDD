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
        public async Task<IActionResult> GetFisioterapeuta()
        {
            var fisioterapeuta = await _IFisioterapeuta.GetFisioterapeuta();
            return Ok(fisioterapeuta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFisioterapeutaById(Guid id)
        {
            var fisioterapeuta = await _IFisioterapeuta.GetFisioterapeutaById(id);
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
        public async Task<IActionResult> AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            await _IFisioterapeuta.AddFisioterapeuta(fisioterapeuta);
            return Ok(fisioterapeuta);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            await _IFisioterapeuta.UpdateFisioterapeuta(fisioterapeuta);
            return Ok("Fisioterapeuta actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFisioterapeuta(Guid id)
        {

            if (await _IFisioterapeuta.GetFisioterapeutaById(id) == null)
            {
                return BadRequest("No se encontro el fisioterapeuta");
            }
            else
            {
                await _IFisioterapeuta.DeleteFisioterapeuta(id);
                return Ok("Fisioterapeuta eliminado correctamente");
            }
        }

    }
}
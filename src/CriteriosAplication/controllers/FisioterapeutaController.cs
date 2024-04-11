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
            var response = await _IFisioterapeuta.AddFisioterapeuta(fisioterapeuta);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            var response = await _IFisioterapeuta.UpdateFisioterapeuta(fisioterapeuta);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFisioterapeuta(Guid id)
        {
            var response = await _IFisioterapeuta.DeleteFisioterapeuta(id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
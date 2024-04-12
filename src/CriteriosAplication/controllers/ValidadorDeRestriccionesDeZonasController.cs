using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [ApiController]
    [Route("services/[controller]")]
    public class ValidadorDeRestriccionesDeZonasController : ControllerBase
    {
        private readonly IValidadorDeRestriccionesDeZonas _validadorDeRestriccionesDeZonas;

        public ValidadorDeRestriccionesDeZonasController(IValidadorDeRestriccionesDeZonas validadorDeRestriccionesDeZonas)
        {
            _validadorDeRestriccionesDeZonas = validadorDeRestriccionesDeZonas;
        }

        [HttpPost]
        public async Task<IActionResult> Validar([FromBody] ValidadorDeRestriccionesDeZonasRequest request)
        {
            var result = await _validadorDeRestriccionesDeZonas.ValidarRestricciones(request);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}
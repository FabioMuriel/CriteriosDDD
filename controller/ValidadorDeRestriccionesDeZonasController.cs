using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
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
        public IActionResult Validar([FromBody] ValidadorDeRestriccionesDeZonasRequest request)
        {
            var result = _validadorDeRestriccionesDeZonas.Validar(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}
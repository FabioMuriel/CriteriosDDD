using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
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

    }
}
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{

    [Route("asterisk/[controller]")]
    [ApiController]
    public class RestriccionesDeZonasController : ControllerBase
    {
        readonly IRestriccionesDeZonasRepository _restriccionesDeZonasRepository;

        public RestriccionesDeZonasController(IRestriccionesDeZonasRepository restriccionesDeZonasRepository)
        {
            _restriccionesDeZonasRepository = restriccionesDeZonasRepository;
        }

        [HttpGet]
        public IActionResult GetRestriccionesDeZonas()
        {
            return Ok(_restriccionesDeZonasRepository.GetRestriccionesDeZonas());
        }
    }
}
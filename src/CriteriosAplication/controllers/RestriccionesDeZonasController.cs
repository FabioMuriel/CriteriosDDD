using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{

    [Route("asterisk/[controller]")]
    [ApiController]
    public class RestriccionesDeZonasController : ControllerBase
    {
        readonly IRestriccionesDeZonasService _restriccionesDeZonasRepository;

        public RestriccionesDeZonasController(IRestriccionesDeZonasService restriccionesDeZonasRepository)
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
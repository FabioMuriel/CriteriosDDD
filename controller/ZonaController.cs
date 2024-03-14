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
    }
}
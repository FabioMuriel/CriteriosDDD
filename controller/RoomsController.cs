using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]

    public class RoomsController : ControllerBase
    {
        readonly IRoomsRepository _roomsRepository;
        public RoomsController(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok(_roomsRepository.GetRooms());
        }

        [HttpPost]
        public IActionResult AddRooms([FromBody] Rooms rooms)
        {
            _roomsRepository.AddRooms(rooms);
            return Ok();
        }
    }
}
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

        [HttpGet("{id}")]
        public IActionResult GetRoomsById(int id)
        {
            return Ok(_roomsRepository.GetRoomsById(id));
        }

        [HttpPost]
        public IActionResult AddRooms([FromBody] Rooms rooms)
        {
            _roomsRepository.AddRooms(rooms);
            return Ok(rooms);
        }

        [HttpPut]
        public IActionResult UpdateRooms([FromBody] Rooms rooms)
        {
            _roomsRepository.UpdateRooms(rooms);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRooms(int id)
        {
            _roomsRepository.DeleteRooms(id);
            return Ok("Room eliminado correctamente");
        }
    }
}
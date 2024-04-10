using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriteriosDeProgramacion.Aplicacion.controller
{
    [Route("asterisk/[controller]")]
    [ApiController]

    public class RoomsController : ControllerBase
    {
        readonly IRoomsService _roomsRepository;
        public RoomsController(IRoomsService roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok(_roomsRepository.GetRooms());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomsById(Guid id)
        {
            if (_roomsRepository.GetRoomsById(id) == null)
            {
                return BadRequest("No se encontro el room");
            }
            else
            {
                _roomsRepository.GetRoomsById(id);
                return Ok(_roomsRepository.GetRoomsById(id));
            }
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
            return Ok("Room actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRooms(Guid id)
        {
            if (_roomsRepository.GetRoomsById(id) == null)
            {
                return BadRequest("No se encontro el room");
            }
            else
            {
                _roomsRepository.DeleteRooms(id);
                return Ok("Room eliminado correctamente");
            }
        }
    }
}
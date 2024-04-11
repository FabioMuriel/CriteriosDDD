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
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomsRepository.GetRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomsById(Guid id)
        {
            if (await _roomsRepository.GetRoomsById(id) == null)
            {
                return BadRequest("No se encontro el room");
            }
            else
            {
                await _roomsRepository.GetRoomsById(id);
                return Ok(await _roomsRepository.GetRoomsById(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRooms([FromBody] Rooms rooms)
        {
            var response = await _roomsRepository.AddRooms(rooms);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRooms([FromBody] Rooms rooms)
        {
            var response = await _roomsRepository.UpdateRooms(rooms);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRooms(Guid id)
        {
            var response = await _roomsRepository.DeleteRooms(id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }
    }
}
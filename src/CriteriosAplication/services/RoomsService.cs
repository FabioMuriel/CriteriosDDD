using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services
{

    public class RoomsService : IRoomsService
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomsService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public async Task<IGenericResponse> AddRooms(Rooms rooms)
        {
            if (rooms == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "Las habitaciones no pueden ser nulas"
                };
            }

            await _roomsRepository.AddRooms(rooms);

            return new GenericResponse
            {
                Success = true,
                Message = "Habitación creada correctamente"
            };
        }

        public async Task<IGenericResponse> DeleteRooms(Guid id)
        {
            Rooms? rooms = await _roomsRepository.GetRoomsById(id);

            if (rooms == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "La habitación no existe"
                };
            }

            await _roomsRepository.DeleteRooms(id);

            return new GenericResponse
            {
                Success = true,
                Message = "Habitación eliminada correctamente"
            };
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _roomsRepository.GetRooms();
        }

        public async Task<Rooms?> GetRoomsById(Guid id)
        {
            Rooms? rooms = await _roomsRepository.GetRoomsById(id);

            if (rooms == null)
            {
                throw new ArgumentException("La habitación no existe");
            }

            return rooms;
        }

        public async Task<IGenericResponse> UpdateRooms(Rooms rooms)
        {
            if (rooms == null)
            {
                return new GenericResponse
                {
                    Success = false,
                    Message = "Las habitaciones no pueden ser nulas"
                };
            }

            await _roomsRepository.UpdateRooms(rooms);

            return new GenericResponse
            {
                Success = true,
                Message = "Habitación actualizada correctamente"
            };
        }

        public class GenericResponse : IGenericResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    }


}
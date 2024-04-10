using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services{

    public class RoomsService : IRoomsService
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomsService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public async Task AddRooms(Rooms rooms)
        {
            if(rooms == null)
            {
                throw new ArgumentException("Las habitaciones no pueden ser nulas");
            }

            await _roomsRepository.AddRooms(rooms);
        }

        public async Task DeleteRooms(Guid id)
        {
            Rooms? rooms = await _roomsRepository.GetRoomsById(id);

            if(rooms == null)
            {
                throw new ArgumentException("La habitación no existe");
            }

            await _roomsRepository.DeleteRooms(id);
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _roomsRepository.GetRooms();
        }

        public async Task<Rooms?> GetRoomsById(Guid id)
        {
            Rooms? rooms = await _roomsRepository.GetRoomsById(id);

            if(rooms == null)
            {
                throw new ArgumentException("La habitación no existe");
            }

            return rooms;
        }

        public async Task UpdateRooms(Rooms rooms)
        {
            if(rooms == null)
            {
                throw new ArgumentException("Las habitaciones no pueden ser nulas");
            }

            await _roomsRepository.UpdateRooms(rooms);
        }
    }


}
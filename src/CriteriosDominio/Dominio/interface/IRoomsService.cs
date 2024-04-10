using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces{
    public interface IRoomsService{
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms?> GetRoomsById(Guid id);
        Task AddRooms(Rooms rooms);
        Task DeleteRooms(Guid id);
        Task UpdateRooms(Rooms rooms);
    }
}
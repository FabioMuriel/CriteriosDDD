using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms?> GetRoomsById(Guid id);
        Task AddRooms(Rooms rooms);
        Task UpdateRooms(Rooms rooms);
        Task DeleteRooms(Guid id);

    }
}
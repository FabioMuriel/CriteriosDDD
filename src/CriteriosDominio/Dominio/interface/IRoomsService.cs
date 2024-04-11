using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces{
    public interface IRoomsService{
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms?> GetRoomsById(Guid id);
        Task<IGenericResponse> AddRooms(Rooms rooms);
        Task<IGenericResponse> DeleteRooms(Guid id);
        Task<IGenericResponse> UpdateRooms(Rooms rooms);
    }
}
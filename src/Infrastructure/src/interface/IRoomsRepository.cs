using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IRoomsRepository
    {
        Rooms GetRoomsById(int id);
        List<Rooms> GetRooms();
        void AddRooms(Rooms rooms);

        void UpdateRooms(Rooms rooms);

        void DeleteRooms(int id);

    }
}
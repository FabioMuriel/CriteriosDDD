using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
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
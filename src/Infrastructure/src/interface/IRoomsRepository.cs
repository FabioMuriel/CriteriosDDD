using CriteriosDominio.Dominio.Modelos.Entidades;

namespace Infrastructure.src.interfaces
{
    public interface IRoomsRepository
    {
        void AddRooms(Rooms rooms);
        List<Rooms> GetRooms();
    }
}
namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Rooms
    {
        public int RoomId { get; set; }
        public string Nombre { get; set; }
        public int ZonaId { get; set; }
        public int ColumnOrder { get; set; }

        public void ValidarRoom(Rooms room)
        {
            if (string.IsNullOrEmpty(room.Nombre))
            {
                throw new Exception("El nombre del cuarto no puede ser nulo");
            }
            if (room.ZonaId == 0)
            {
                throw new Exception("La zona del cuarto no puede ser nula");
            }
            if (room.ColumnOrder == 0)
            {
                throw new Exception("El orden de la columna no puede ser nulo");
            }
        }

    }
}
namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Rooms
    {
        public Guid RoomId { get; private set; }
        public string Nombre { get; private set; }
        public Guid ZonaId { get; private set; }
        public int ColumnOrder { get; private set; }

        private Rooms()
        {
        }
        
        public Rooms(Guid roomId, string nombre, Guid zonaId, int columnOrder)
        {
            RoomId = SetRoomId(roomId);
            Nombre = SetNombre(nombre);
            ZonaId = SetZonaId(zonaId);
            ColumnOrder = SetColumnOrder(columnOrder);
        }

        public Guid SetRoomId(Guid guid) => RoomId = guid;
        public string SetNombre(string nombre) => ValidarNombre(nombre);
        public Guid SetZonaId(Guid zonaId) => ZonaId = zonaId;
        public int SetColumnOrder(int columnOrder) => ColumnOrder = columnOrder;

        public static string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El nombre de la sala no puede estar vacío";
            }
            
            return nombre;
        }        

    }
}
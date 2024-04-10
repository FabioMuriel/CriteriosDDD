namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Rooms
    {
        public Guid RoomId { get; private set; }
        public string Nombre { get; private set; }
        public int ZonaId { get; private set; }
        public int ColumnOrder { get; private set; }

        private Rooms()
        {
        }
        
        public Rooms(Guid roomId, string nombre, int zonaId, int columnOrder)
        {
            RoomId = roomId;
            Nombre = nombre;
            ZonaId = zonaId;
            ColumnOrder = columnOrder;
        }

        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetZonaId(int zonaId) => ZonaId = zonaId;
        public void SetColumnOrder(int columnOrder) => ColumnOrder = columnOrder;

        public static string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El nombre de la sala no puede estar vacío";
            }
            return string.Empty;
        }        

    }
}
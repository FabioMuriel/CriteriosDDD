namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Zona
    {
        public Guid ZonaId { get; private set; }
        public string Nombre { get; private set; }
        public string Rooms { get; private set; }

        private Zona()
        {
        }

        public Zona(Guid zonaId, string nombre, string rooms)
        {
            ZonaId = SetGuid(zonaId);
            Nombre = SetNombre(nombre);
            Rooms = SetRooms(rooms);
        }

        public Guid SetGuid(Guid guid) => ZonaId = guid;
        public string SetNombre(string nombre) => ValidarNombre(nombre);
        public string SetRooms(string rooms) => ValidarRooms(rooms);

        private static string ValidarNombre(string nombre)
        {

            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("El nombre de la zona no puede estar vacio");
            }

            return nombre;
        }

        private static string ValidarRooms(string rooms)
        {
            if (string.IsNullOrEmpty(rooms))
            {
                throw new Exception("La zona debe tener al menos una sala");
            }

            return rooms;
        }

    }
}
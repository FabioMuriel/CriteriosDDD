namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class RestriccionesDeZonas
    {
        public int RestriccionesDeZonasId { get; private set; }
        public string Nombre { get; private set; }
        public string FromRooms { get; private set; }
        public string ToRooms { get; private set; }
        public string Regla { get; private set; }

       private RestriccionesDeZonas()
        {
        }
       
        public RestriccionesDeZonas(string nombre, string fromRooms, string toRooms, string regla)
        {
            Nombre = ValidateNombre(nombre);
            FromRooms = ValidateFromRooms(fromRooms);
            ToRooms = ValidateToRooms(toRooms);
            Regla = ValidateRegla(regla);
        }

        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetFromRooms(string fromRooms) => FromRooms = fromRooms;
        public void SetToRooms(string toRooms) => ToRooms = toRooms;
        public void SetRegla(string regla) => Regla = regla;

        private static string ValidateNombre (string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacio");
            }

            return nombre;
        }

        private static string ValidateFromRooms (string fromRooms)
        {
            if (string.IsNullOrEmpty(fromRooms))
            {
                throw new ArgumentException("El fromRooms no puede ser nulo o vacio");
            }

            return fromRooms;
        }

        private static string ValidateToRooms (string toRooms)
        {
            if (string.IsNullOrEmpty(toRooms))
            {
                throw new ArgumentException("El toRooms no puede ser nulo o vacio");
            }

            return toRooms;
        }

        private static string ValidateRegla (string regla)
        {
            if (string.IsNullOrEmpty(regla))
            {
                throw new ArgumentException("La regla no puede ser nulo o vacio");
            }

            return regla;
        } 


    }
}
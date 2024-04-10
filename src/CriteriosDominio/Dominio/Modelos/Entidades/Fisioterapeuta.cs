namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Fisioterapeuta
    {
        public Guid FisioterapeutaId { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public int Rango { get; private set; }

        public Fisioterapeuta(Guid fisioterapeutaId, string nombre, string apellido, int rango)
        {
            FisioterapeutaId = SetFisioterapeutaId(fisioterapeutaId);
            Nombre = ValidarNombreFisioterapeuta(nombre);
            Apellido = ValidarApellidoFisioterapeuta(apellido);
            Rango = ValidarRangoFisioterapeuta(rango);
        }
        
        public Guid SetFisioterapeutaId(Guid fisioterapeutaId) => FisioterapeutaId = fisioterapeutaId;
        public string SetNombre(string nombre) => Nombre = ValidarNombreFisioterapeuta(nombre);
        public string SetApellido(string apellido) => Apellido = ValidarApellidoFisioterapeuta(apellido);
        public int SetRango(int rango) => Rango = ValidarRangoFisioterapeuta(rango);

        private static string ValidarNombreFisioterapeuta(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre del fisioterapeuta no puede ser nulo o vacío");
            }

            return nombre;
        }

        private static string ValidarApellidoFisioterapeuta(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                throw new ArgumentException("El apellido del fisioterapeuta no puede ser nulo o vacío");
            }

            return apellido;
        }

        private static int ValidarRangoFisioterapeuta(int rango)
        {
            if (rango != 10 && rango != 20 && rango != 30)
            {
                throw new ArgumentException("Los rangos de los fisioterapeutas disponibles son 10, 20 y 30");
            }

            if (string.IsNullOrEmpty(rango.ToString()))
            {
                throw new ArgumentException("El rango del fisioterapeuta no puede ser nulo o vacío");
            }

            return rango;
        }

    }

}
namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Fisioterapeuta
    {
        public int FisioterapeutaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public void ValidarFisioreapeuta(Fisioterapeuta fisioterapeuta)
        {
            if (string.IsNullOrEmpty(fisioterapeuta.Nombre))
            {
                throw new Exception("El nombre del fisioterapeuta no puede ser nulo");
            }
            if (string.IsNullOrEmpty(fisioterapeuta.Apellido))
            {
                throw new Exception("El apellido del fisioterapeuta no puede ser nulo");
            }
        }

    }

}
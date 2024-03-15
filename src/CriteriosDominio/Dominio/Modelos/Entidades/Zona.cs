namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Zona
    {
        public int ZonaId { get; set; }
        public string Nombre { get; set; }
        public string Rooms { get; set; }

        public void ValidarZona(Zona zona)
        {
            if (string.IsNullOrEmpty(zona.Nombre))
            {
                throw new Exception("El nombre de la zona no puede ser nulo");
            }
            if (string.IsNullOrEmpty(zona.Rooms))
            {
                throw new Exception("La zona no puede estar vacia");
            }
        }
    }
}
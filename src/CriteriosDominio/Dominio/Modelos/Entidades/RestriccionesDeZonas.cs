namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class RestriccionesDeZonas
    {
        public int RestriccionesDeZonasId { get; set; }
        public string Nombre { get; set; }
        public string FromRooms { get; set; }
        public string ToRooms { get; set; }

    }
}
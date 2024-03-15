namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Sched
    {
        public int SchedId { get; set; }
        public int FisioterapeutaId { get; set; }
        public int RoomId { get; set; }
        public int Hora { get; set; }
        public DateTime Fecha { get; set; }
    }
}
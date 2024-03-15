namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Sched
    {
        public int SchedId { get; set; }
        public int FisioterapeutaId { get; set; }
        public int RoomId { get; set; }
        public int Hora { get; set; }
        public DateTime Fecha { get; set; }

        public void ValidarSched(Sched sched)
        {
            if (sched.FisioterapeutaId <= 0)
            {
                throw new Exception("El id del fisioterapeuta no puede ser nulo");
            }
            if (sched.RoomId <= 0)
            {
                throw new Exception("El id del room no puede ser nulo");
            }
            if (sched.Hora < 6)
            {
                throw new Exception("La hora no puede ser nula");
            }
            if (sched.Fecha == null)
            {
                throw new Exception("La fecha no puede ser nula");
            }
        }
    }
}
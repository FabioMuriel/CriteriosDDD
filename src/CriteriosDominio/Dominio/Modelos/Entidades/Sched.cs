namespace CriteriosDominio.Dominio.Modelos.Entidades
{
    public class Sched
    {
        public Guid SchedId { get; private set; }
        public Guid FisioterapeutaId { get; private set; }
        public int RoomId { get; private set; }
        public int Hora { get; private set; }
        public DateOnly Fecha { get; private set; }

        private Sched()
        {
        }

        public Sched(Guid schedId, Guid fisioterapeutaId, int roomId, int hora, DateOnly fecha)
        {
            SchedId = SetSchedId(schedId);
            FisioterapeutaId = SetFisioterapeutaId(fisioterapeutaId);
            RoomId = SetRoomId(roomId);
            Hora = SetHora(hora);
            Fecha = SetFecha(fecha);
        }

        public Guid SetSchedId(Guid guid) => ValidarSchedId(guid);
        public Guid SetFisioterapeutaId(Guid fisioterapeutaId) => ValidarFisioterapeutaId(fisioterapeutaId);
        public int SetRoomId(int roomId) => RoomId = roomId;
        public int SetHora(int hora) => ValidarHora(hora);
        public DateOnly SetFecha(DateOnly fecha) => ValidarFecha(fecha);

        public static Guid ValidarSchedId(Guid schedId)
        {
            if (schedId == Guid.Empty)
            {
                throw new ArgumentException("El schedId no puede ser nulo");
            }

            return schedId;
        }

        public static Guid ValidarFisioterapeutaId(Guid fisioterapeutaId)
        {
            if (fisioterapeutaId == Guid.Empty)
            {
                throw new ArgumentException("El fisioterapeutaId no puede ser nulo");
            }

            return fisioterapeutaId;
        }

        private static int ValidarHora(int hora)
        {
            if (hora < 6 || hora > 18)
            {
                throw new ArgumentException("La hora debe estar entre 6 y 18");
            }

            return hora;
        }

        private static DateOnly ValidarFecha(DateOnly fecha)
        {
            if (fecha == default(DateOnly))
            {
                throw new ArgumentException("La fecha no puede ser nula");
            }

            if(fecha < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("La fecha no puede ser menor a la fecha actual");
            }

            return fecha;
        }

        private static int ValidarRoomId(int roomId)
        {
            if (roomId < 1)
            {
                throw new ArgumentException("El room no es valido, no puede ser menor a 1");
            }

            return roomId;
        }

    }
}
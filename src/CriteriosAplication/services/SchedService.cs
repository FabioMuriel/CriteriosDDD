using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.Servicios;

namespace CriteriosAplicaion.Services
{
    public class SchedService : ISchedService
    {
        private readonly ISchedRepository _schedRepository;
        private readonly IPosicionDeAgendamientoValido _posicionDeAgendamientoValido;

        public SchedService(ISchedRepository schedRepository, IPosicionDeAgendamientoValido posicionDeAgendamientoValido)
        {
            _schedRepository = schedRepository;
            _posicionDeAgendamientoValido = posicionDeAgendamientoValido;
        }

        public async Task AddSched(Sched sched)
        {
            await ValidarDisponibilidadDeEspacio(sched.RoomId, sched.FisioterapeutaId, sched.Hora, sched.Fecha);

            if (sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.AddSched(sched);
        }

        public async Task DeleteSched(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if (sched == null)
            {
                throw new ArgumentException("El sched no existe");
            }

            await _schedRepository.DeleteSched(id);
        }

        public async Task<IEnumerable<Sched>> GetSched()
        {
            return await _schedRepository.GetSched();
        }

        public async Task<Sched?> GetSchedById(Guid id)
        {
            Sched? sched = await _schedRepository.GetSchedById(id);

            if (sched == null)
            {
                throw new ArgumentException("El sched no existe");
            }

            return sched;
        }

        public async Task UpdateSched(Sched sched)
        {
            await ValidarDisponibilidadDeEspacio(sched.RoomId, sched.FisioterapeutaId, sched.Hora, sched.Fecha);

            if (sched == null)
            {
                throw new ArgumentException("El sched no puede ser nulo");
            }

            await _schedRepository.UpdateSched(sched);
        }

        private async Task ValidarDisponibilidadDeEspacio(Guid RoomId, Guid FisioterapeutaId, int Hora, DateTime Fecha)
        {
            var espacioDisponible = await _posicionDeAgendamientoValido.ValidarPosicion(new PosicionDeAgendamientoValidoRequest
            {
                RoomId = RoomId,
                FisioterapeutaId = FisioterapeutaId,
                Hora = Hora,
                Fecha = Fecha
            });

            if (espacioDisponible.EspacioDisponible == false)
            {
                throw new ArgumentException("El espacio no esta disponible");
            }
        }
    }
}
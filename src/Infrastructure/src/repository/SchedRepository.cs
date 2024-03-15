using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;
using CriteriosDominio.Dominio.Servicios;

namespace Infrastructure.src.repository
{
    public class SchedRepository : ISchedRepository
    {
        public SchedRepository()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Sched.Any())
                {

                    var scheds = new List<Sched> {
                        new Sched
                        {
                            SchedId = 1,
                            Fecha = DateTime.Now,
                            FisioterapeutaId = 1,
                            RoomId = 1,
                            Hora = 9
                        },
                        new Sched
                        {
                            SchedId = 2,
                            Fecha = DateTime.Now,
                            FisioterapeutaId = 2,
                            RoomId = 2,
                            Hora = 10
                        }
                    };

                    context.AddRange(scheds);
                    context.SaveChanges();
                }
            }
        }

        public List<Sched> GetSched()
        {
            using (var context = new AppDbContext())
            {
                return context.Sched.ToList();
            }

        }

        public void AddSched(Sched sched)
        {
            using (var context = new AppDbContext())
            {
                int lasId = context.Sched.Max(x => x.SchedId) + 1;
                sched.SchedId = lasId;
                context.Sched.Add(sched);
                context.SaveChanges();
            }
        }

        public void UpdateSched(Sched sched)
        {
            using (var context = new AppDbContext())
            {
                context.Sched.Update(sched);
                context.SaveChanges();
            }
        }

        public void DeleteSched(int id)
        {
            using (var context = new AppDbContext())
            {
                var sched = context.Sched.FirstOrDefault(x => x.SchedId == id);
                context.Sched.Remove(sched);
                context.SaveChanges();
            }
        }
    }
}
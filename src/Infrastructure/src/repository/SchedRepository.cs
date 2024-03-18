using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;

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
                            Fecha = DateTime.Now,
                            FisioterapeutaId = 1,
                            RoomId = 1,
                            Hora = 9
                        },
                        new Sched
                        {
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

        public Sched GetSchedById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Sched.Find(id)!;
            }
        }

        public void AddSched(Sched sched)
        {
            using (var context = new AppDbContext())
            {
                ValidationHelper.ValidateEntity(sched);
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
                ValidationHelper.ValidateEntity(sched);
                context.Sched.Update(sched);
                context.SaveChanges();
            }
        }

        public void DeleteSched(int id)
        {
            using (var context = new AppDbContext())
            {
                var sched = context.Sched.FirstOrDefault(x => x.SchedId == id);
                if (sched != null)
                {
                    context.Sched.Remove(sched);
                    context.SaveChanges();
                }
            }
        }

    }
}
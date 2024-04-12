using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.repository
{
    public class SchedRepository : ISchedRepository
    {
        private readonly AppDbContext _context;

        public SchedRepository(AppDbContext context)
        {
            _context = context;

            DateTime fecha = DateTime.Now;
            string fechaFormateada = fecha.ToString("yyyy/MM/dd");

            if (_context.Sched.CountAsync().Result == 0)
            {
                _context.Sched.Add(
                    new Sched(
                        Guid.Parse("7b87ce3c-e801-4f82-9de5-5bd49fe50031"),
                        Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64"),
                        Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a"),
                        6,
                        fechaFormateada
                    )
                );

                _context.SaveChanges();
            }
        }

        public async Task AddSched(Sched sched)
        {
            ValidationHelper.ValidateEntity(sched);

            await _context.Sched.AddAsync(sched);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSched(Guid id)
        {
            var sched = await _context.Sched.FindAsync(id);
            if (sched == null)
            {
                throw new Exception("Sched not found");
            }

            _context.Sched.Remove(sched);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sched>> GetSched()
        {
            var sched = await _context.Sched.ToListAsync();

            if (sched == null)
            {
                throw new Exception("Sched not found");
            }

            return sched;
        }

        public async Task<Sched> GetSchedById(Guid id)
        {
            Sched? sched = await _context.Sched.FindAsync(id);

            if (sched == null)
            {
                throw new Exception("Sched not found");
            }

            return sched;
        }

        public async Task UpdateSched(Sched sched)
        {
            ValidationHelper.ValidateEntity(sched);
            _context.Sched.Update(sched);
            await _context.SaveChangesAsync();
        }
    }
}
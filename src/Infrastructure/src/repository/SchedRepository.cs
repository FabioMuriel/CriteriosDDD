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
            return await _context.Sched.ToListAsync();   
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
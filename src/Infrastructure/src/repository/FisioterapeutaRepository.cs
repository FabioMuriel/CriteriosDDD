using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.repository
{
    public class FisioterapeutaRepository : IFisioterapeutaRepository
    {
        private readonly AppDbContext _context;

        public FisioterapeutaRepository(AppDbContext context)
        {
            _context = context;

            if (_context.Fisioterapeutas.CountAsync().Result == 0)
            {
                _context.Fisioterapeutas.Add(new Fisioterapeuta(Guid.NewGuid(), "Juan", "Perez", 10));
                _context.Fisioterapeutas.Add(new Fisioterapeuta(Guid.NewGuid(), "Maria", "Gonzalez", 20));
                _context.Fisioterapeutas.Add(new Fisioterapeuta(Guid.NewGuid(), "Pedro", "Rodriguez", 30));
                _context.SaveChanges();
            }

        }

        public async Task AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            ValidationHelper.ValidateEntity(fisioterapeuta);

            await _context.Fisioterapeutas.AddAsync(fisioterapeuta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFisioterapeuta(Guid id)
        {
            var fisioterapeuta = await _context.Fisioterapeutas.FindAsync(id);

            if (fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            _context.Fisioterapeutas.Remove(fisioterapeuta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta()
        {
            var fisioterapeutas = await _context.Fisioterapeutas.ToListAsync();

            if (fisioterapeutas == null)
            {
                throw new ArgumentException("No hay fisioterapeutas registrados");
            }

            return fisioterapeutas;
        }

        public async Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id)
        {
            var fisioterapeuta = await _context.Fisioterapeutas.FindAsync(id);

            if (fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            return fisioterapeuta;
        }

        public async Task UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            var fisioterapeutaToUpdate = await _context.Fisioterapeutas.FindAsync(fisioterapeuta.FisioterapeutaId);

            if (fisioterapeutaToUpdate == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            fisioterapeutaToUpdate.SetNombre(fisioterapeuta.Nombre);
            fisioterapeutaToUpdate.SetApellido(fisioterapeuta.Apellido);
            fisioterapeutaToUpdate.SetRango(fisioterapeuta.Rango);

            await _context.SaveChangesAsync();
        }
    }
}
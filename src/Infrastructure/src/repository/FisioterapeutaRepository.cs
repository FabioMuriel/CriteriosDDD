using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;

namespace Infrastructure.src.repository
{
    public class FisioterapeutaRepository : IFisioterapeuta
    {

        public FisioterapeutaRepository()
        {

            using (var context = new AppDbContext())
            {
                if (!context.Fisioterapeuta.Any())
                {
                    var fisioterapeutas = new List<Fisioterapeuta> {
                        new Fisioterapeuta
                        {
                            FisioterapeutaId = 1,
                            Nombre = "Juan",
                            Apellido = "Perez"
                        },
                        new Fisioterapeuta
                        {
                            FisioterapeutaId = 2,
                            Nombre = "Pedro",
                            Apellido = "Gomez"
                        }
                    };

                    context.AddRange(fisioterapeutas);
                    context.SaveChanges();
                }
            }

        }

        public List<Fisioterapeuta> GetFisioterapeuta()
        {
            using (var context = new AppDbContext())
            {
                return context.Fisioterapeuta.ToList();
            }
        }

        public void AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            using (var context = new AppDbContext())
            {
                int lasId = context.Fisioterapeuta.Max(x => x.FisioterapeutaId) + 1;
                fisioterapeuta.FisioterapeutaId = lasId;
                context.Add(fisioterapeuta);
                context.SaveChanges();
            }
        }

        public void UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            using (var context = new AppDbContext())
            {
                context.Update(fisioterapeuta);
                context.SaveChanges();
            }
        }

        public void DeleteFisioterapeuta(int id)
        {
            using (var context = new AppDbContext())
            {
                var fisioterapeuta = context.Fisioterapeuta.Find(id);
                context.Fisioterapeuta.Remove(fisioterapeuta);
                context.SaveChanges();
            }
        }
    }
}
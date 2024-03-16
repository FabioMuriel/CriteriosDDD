using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;

namespace Infrastructure.src.repository
{
    public class RestriccionesDeZonasRepository : IRestriccionesDeZonasRepository
    {

        public RestriccionesDeZonasRepository()
        {
            using (var context = new AppDbContext())
            {
                if (!context.RestriccionesDeZonas.Any())
                {
                    var restriccionesDeZonas = new List<RestriccionesDeZonas> {
                    new RestriccionesDeZonas
                    {
                        Nombre = "Los fisioterapeutas que estén ubicados en camillas N° 0, 1 y 2 solo pueden programar en la mano N°2, 3 y 4",
                        FromRooms = "1-1-1-0-0-0-0-0-0-0-0-0-0-0-0-0-0-0",
                        ToRooms = "0-0-0-0-0-0-0-0-0-0-0-1-1-1-0-0-0-0",
                    },
                    new RestriccionesDeZonas
                    {
                        Nombre = "Los fisioterapeutas que estén ubicados en camillas  N° 3, 4 y 5 solo pueden programar en la mano N°6, 7 y 8 ",
                        FromRooms = "0-0-0-1-1-1-0-0-0-0-0-0-0-0-0-0-0-0",
                        ToRooms = "0-0-0-0-0-0-0-0-0-0 -0-0-0-0-0-1-1-1",
                    }
                };

                    context.AddRange(restriccionesDeZonas);
                    context.SaveChanges();
                }
            }
        }

        public List<RestriccionesDeZonas> GetRestriccionesDeZonas()
        {
            using (var context = new AppDbContext())
            {
                return context.RestriccionesDeZonas.ToList();
            }
        }
    }

}
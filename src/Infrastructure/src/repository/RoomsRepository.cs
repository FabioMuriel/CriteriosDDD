using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.src.interfaces;

namespace Infrastructure.src.repository
{
    public class RoomsRepository : IRoomsRepository
    {
        public RoomsRepository()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Rooms.Any())
                {
                    for (int i = 0; i < 11; i++)
                    {
                        context.Rooms.Add(new Rooms
                        {
                            RoomId = i + 1,
                            Nombre = "CAMILLA " + i,
                            ZonaId = 1,
                            ColumnOrder = i
                        });
                    }

                    for (int i = 12; i < 19; i++)
                    {
                        context.Rooms.Add(new Rooms
                        {
                            RoomId = i,
                            Nombre = "MANO ",
                            ZonaId = 2,
                            ColumnOrder = i
                        });
                    }

                    context.SaveChanges();
                }
            }
        }

        public void AddRooms(Rooms rooms)
        {
            using (var context = new AppDbContext())
            {
                int lasId = context.Rooms.Max(x => x.RoomId) + 1;
                int lastColumnOrd = context.Rooms.Max(x => x.ColumnOrder) + 1;
                rooms.RoomId = lasId;
                rooms.ColumnOrder = lastColumnOrd;
                context.Rooms.Add(rooms);
                context.SaveChanges();
            }
        }

        public List<Rooms> GetRooms()
        {
            using (var context = new AppDbContext())
            {
                return context.Rooms.ToList();
            }
        }

        public void UpdateRooms(Rooms rooms)
        {
            using (var context = new AppDbContext())
            {
                context.Rooms.Update(rooms);
                context.SaveChanges();
            }
        }

        public void DeleteRooms(int id)
        {
            using (var context = new AppDbContext())
            {
                var room = context.Rooms.Find(id);
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }

    }
}
using Infrastructure.contexto;
using CriteriosDominio.Dominio.Modelos.Entidades;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.src.repository
{
    public class RoomsRepository : IRoomsRepository
    {

        private readonly AppDbContext _context;
        public RoomsRepository(AppDbContext context)
        {
            _context = context;
            // using (var context = new AppDbContext())
            // {
            //     if (!context.Rooms.Any())
            //     {
            //         for (int i = 0; i < 11; i++)
            //         {
            //             context.Rooms.Add(new Rooms
            //             {
            //                 RoomId = i + 1,
            //                 Nombre = "CAMILLA " + i,
            //                 ZonaId = 1,
            //                 ColumnOrder = i
            //             });
            //         }

            //         for (int i = 12; i < 19; i++)
            //         {
            //             context.Rooms.Add(new Rooms
            //             {
            //                 RoomId = i,
            //                 Nombre = "MANO " + i,
            //                 ZonaId = 2,
            //                 ColumnOrder = i - 1
            //             });
            //         }

            //         context.SaveChanges();
            //     }
            // }
        }

        public async Task AddRooms(Rooms rooms)
        {

            ValidationHelper.ValidateEntity(rooms);

            await _context.Rooms.AddAsync(rooms);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
 
            var rooms = await _context.Rooms.ToListAsync();

            if (rooms == null)
            {
                throw new ArgumentNullException(nameof(rooms));
            }

            return rooms;
        }


        public async Task DeleteRooms(Guid id)
        {
            Rooms? rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                throw new ArgumentNullException(nameof(rooms));
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();
        }

        public async Task<Rooms?> GetRoomsById(Guid id)
        {
            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                throw new ArgumentNullException(nameof(rooms));
            }

            return rooms;
        }

        public async Task UpdateRooms(Rooms rooms)
        {
            var roomsToUpdate = await _context.Rooms.FindAsync(rooms.RoomId);

            if (roomsToUpdate == null)
            {
                throw new ArgumentNullException(nameof(roomsToUpdate));
            }

            roomsToUpdate.SetNombre(rooms.Nombre);
            roomsToUpdate.SetZonaId(rooms.ZonaId);
            roomsToUpdate.SetColumnOrder(rooms.ColumnOrder);

            await _context.SaveChangesAsync();
        }
    }
}
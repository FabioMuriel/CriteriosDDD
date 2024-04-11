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

            if (_context.Rooms.CountAsync().Result == 0)
            {

                _context.Rooms.AddRange(new List<Rooms>{
                    new(Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a"), "CAMILLA 1", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 1),
                    new(Guid.Parse("23f9edbb-7608-4ae3-85ee-5308c79b8100"), "CAMILLA 2", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 2),
                    new(Guid.Parse("06c0c09c-df34-4330-86e6-0511ba33565a"), "CAMILLA 3", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 3),
                    new(Guid.Parse("306f349a-d9b6-4700-a149-3c780d0d74a9"), "CAMILLA 4", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 4),
                    new(Guid.Parse("5545323f-f2c7-4436-a06d-1184617eddaa"), "CAMILLA 5", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 5),
                    new(Guid.Parse("f3b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), "CAMILLA 6", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 6),
                    new(Guid.Parse("0fa8dca3-43df-45c2-ae30-3451c304c37f"), "CAMILLA 7", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 7),
                    new(Guid.Parse("dea30dd4-53ef-459d-84d0-f925206697ef"), "CAMILLA 8", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 8),
                    new(Guid.Parse("23e5a538-a336-439e-aa6b-5b31fb8fd8ce"), "CAMILLA 9", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 9),
                    new(Guid.Parse("2cd592bf-ffbe-44d8-9851-b0f069610dcc"), "CAMILLA 10", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"),10),

                    new(Guid.Parse("93126113-be52-4008-9d1e-90aee0e53a70"), "MANO 1", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 11),
                    new(Guid.Parse("8f9be634-4864-475e-a08d-a94ec25b8d78"), "MANO 2", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 12),
                    new(Guid.Parse("e57df18a-fcd8-46a4-ba81-aaad6fbbd98f"), "MANO 3", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 13),
                    new(Guid.Parse("a70bfa47-00c0-4de1-818d-053d4b31a7c9"), "MANO 4", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 14),
                    new(Guid.Parse("4d0a7834-0dc2-4bfb-8c7f-e4578c5d5fa3"), "MANO 5", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 15),
                    new(Guid.Parse("c02cf78c-6d8f-4f53-b4b6-2257b143cbdf"), "MANO 6", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 16),
                    new(Guid.Parse("f6b33396-c180-4154-b5ad-26ba50d52e44"), "MANO 7", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 17),
                    new(Guid.Parse("ed04bf65-bd66-4a53-8875-a14a5bf0e0a7"), "MANO 8", Guid.Parse("e7e08d2d-f0f6-4dce-a259-04eaff682b68"), 18),

                });

                context.SaveChanges();
            }
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
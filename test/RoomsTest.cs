using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;

namespace test
{
    public class RoomsTest
    {
        public RoomsTest()
        {

        }

        private static AppDbContext CreateMemoryContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .EnableSensitiveDataLogging()
                .Options;

            var context = new AppDbContext(options);
            return context;
        }

        [Fact]
        public async Task AddRoomTest()
        {
            var context = CreateMemoryContext("AddRoomTest");
            var repository = new RoomsRepository(context);
            var service = new RoomsService(repository);

            var room = new Rooms
            (
                Guid.NewGuid(),
                "Room 1",
                Guid.NewGuid(),
                1
            );

            var response = await service.AddRooms(room);
            
            Assert.True(response.Success);
            Assert.Equal("Habitación creada correctamente", response.Message);

        }

        [Fact]
        public async Task GetRoomByIdTest()
        {
            var context = CreateMemoryContext("GetRoomByIdTest");
            var repository = new RoomsRepository(context);
            var service = new RoomsService(repository);

            var room = new Rooms
            (
                Guid.NewGuid(),
                "Room 1",
                Guid.NewGuid(),
                1
            );

            await service.AddRooms(room);

            var response = await service.GetRooms();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetRoomsTest()
        {
            var context = CreateMemoryContext("GetRoomsTest");
            var repository = new RoomsRepository(context);
            var service = new RoomsService(repository);

            var room = new Rooms(Guid.NewGuid(), "Room 1", Guid.NewGuid(), 1);
            var room2 = new Rooms(Guid.NewGuid(), "Room 2", Guid.NewGuid(), 2);
            var room3 = new Rooms(Guid.NewGuid(), "Room 3", Guid.NewGuid(), 3);

            await service.AddRooms(room);
            await service.AddRooms(room2);
            await service.AddRooms(room3);

            var response = await service.GetRooms();
            Assert.NotNull(response);
            Assert.Equal(21, response.Count());

        }

        [Fact]
        public async Task DeleteRoomTest()
        {
            var context = CreateMemoryContext("DeleteRoomTest");
            var repository = new RoomsRepository(context);
            var service = new RoomsService(repository);

            var room = new Rooms
            (
                Guid.NewGuid(),
                "Room 1",
                Guid.NewGuid(),
                1
            );

            await service.AddRooms(room);

            var response = await service.DeleteRooms(room.RoomId);
            Assert.True(response.Success);
            Assert.Equal("Habitación eliminada correctamente", response.Message);
        }

        
        
    }
}
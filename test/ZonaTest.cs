using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;

namespace test
{
    public class ZonaTest
    {
        public ZonaTest()
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
        public async Task AddZonaTest()
        {
            var context = CreateMemoryContext("AddZonaTest");
            var repository = new ZonasRepository(context);
            var service = new ZonaService(repository);

            var zona = new Zona
            (
                Guid.NewGuid(),
                "Zona 1",
                "1, 2, 3, 4, 5, 6, 7, 8, 9, 10"
            );

            var response = await service.AddZona(zona);

            Assert.True(response.Success);
            Assert.Equal("Zona creada correctamente", response.Message);

        }

        [Fact]
        public async Task GetZonaByIdTest()
        {
            var context = CreateMemoryContext("GetZonaByIdTest");
            var repository = new ZonasRepository(context);
            var service = new ZonaService(repository);

            var zona = new Zona
            (
                Guid.NewGuid(),
                "Zona 1",
                "1, 2, 3, 4, 5, 6, 7, 8, 9, 10"
            );

            await service.AddZona(zona);

            var response = await service.GetZonaById(zona.ZonaId);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetZonasTest()
        {
            var context = CreateMemoryContext("GetZonasTest");
            var repository = new ZonasRepository(context);
            var service = new ZonaService(repository);

            var zona = new Zona(Guid.NewGuid(), "Zona 1", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10");
            var zona2 = new Zona(Guid.NewGuid(), "Zona 2", "11, 12, 13, 14, 15, 16, 17");
            var zona3 = new Zona(Guid.NewGuid(), "Zona 3", "18, 19, 20, 21, 22, 23, 24");

            await service.AddZona(zona);
            await service.AddZona(zona2);
            await service.AddZona(zona3);

            var response = await service.GetZonas();

            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.Equal(5, response.Count());
        }

        [Fact]
        public async Task DeleteZonaTest()
        {
            var context = CreateMemoryContext("DeleteZonaTest");
            var repository = new ZonasRepository(context);
            var service = new ZonaService(repository);

            var zona = new Zona
            (
                Guid.NewGuid(),
                "Zona 1",
                "1, 2, 3, 4, 5, 6, 7, 8, 9, 10"
            );

            await service.AddZona(zona);

            var response = await service.DeleteZona(zona.ZonaId);
            Assert.True(response.Success);
            Assert.Equal("Zona eliminada correctamente", response.Message);
        }

    }
}
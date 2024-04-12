using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;

namespace test
{
    public class FisioterapeutaTest
    {
        public FisioterapeutaTest()
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
        public async Task AddFisioterapeutaTest()
        {
            var context = CreateMemoryContext("AddFisioterapeutaTest");
            var repository = new FisioterapeutaRepository(context);
            var service = new FisioterapeutaService(repository);

            var fisioterapeuta = new Fisioterapeuta
            (
                Guid.NewGuid(),
                "Fisioterapeuta 1",
                "Apellido 1",
                10
            );

            var response = await service.AddFisioterapeuta(fisioterapeuta);
            Assert.True(response.Success);
            Assert.Equal("Fisioterapeuta creado correctamente", response.Message);

        }

        [Fact]
        public async Task GetFisioterapeutaByIdTest()
        {
            var context = CreateMemoryContext("GetFisioterapeutaByIdTest");
            var repository = new FisioterapeutaRepository(context);
            var service = new FisioterapeutaService(repository);

            var fisioterapeuta = new Fisioterapeuta
            (
                Guid.NewGuid(),
                "Fisioterapeuta 1",
                "Apellido 1",
                10
            );

            await service.AddFisioterapeuta(fisioterapeuta);

            var response = await service.GetFisioterapeutaById(fisioterapeuta.FisioterapeutaId);

            Assert.NotNull(response);
            Assert.Equal(fisioterapeuta.FisioterapeutaId, response.FisioterapeutaId);

        }

        [Fact]
        public async Task DeleteFisioterapeutaTest()
        {
            var context = CreateMemoryContext("DeleteFisioterapeutaTest");
            var repository = new FisioterapeutaRepository(context);
            var service = new FisioterapeutaService(repository);

            var fisioterapeuta = new Fisioterapeuta
            (
                Guid.NewGuid(),
                "Fisioterapeuta 1",
                "Apellido 1",
                10
            );

            await service.AddFisioterapeuta(fisioterapeuta);

            var response = await service.DeleteFisioterapeuta(fisioterapeuta.FisioterapeutaId);

            Assert.True(response.Success);
            Assert.Equal("Fisioterapeuta eliminado correctamente", response.Message);

        }

        [Fact]
        public async Task GetFisioterapeutaTest()
        {
            var context = CreateMemoryContext("GetFisioterapeutaTest");
            var repository = new FisioterapeutaRepository(context);
            var service = new FisioterapeutaService(repository);

            var fisioterapeuta = new Fisioterapeuta(Guid.NewGuid(), "Fisioterapeuta 1", "Apellido 1", 10);
            var fisioterapeuta2 = new Fisioterapeuta(Guid.NewGuid(), "Fisioterapeuta 2", "Apellido 2", 20);
            var fisioterapeuta3 = new Fisioterapeuta(Guid.NewGuid(), "Fisioterapeuta 3", "Apellido 3", 30);

            await service.AddFisioterapeuta(fisioterapeuta);
            await service.AddFisioterapeuta(fisioterapeuta2);
            await service.AddFisioterapeuta(fisioterapeuta3);

            var response = await service.GetFisioterapeuta();

            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.Equal(6, response.Count());

        }

    }
}
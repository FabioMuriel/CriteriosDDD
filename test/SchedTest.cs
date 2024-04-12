using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;

namespace test
{
    public class SchedTest
    {
        public SchedTest()
        {

        }

        private static DateTime fecha = DateTime.Now;
        private static string fechaFormateada = fecha.ToString("yyyy/MM/dd");

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
        public async Task AddSchedTest()
        {
            var context = CreateMemoryContext("AddSchedTest");
            var repository = new SchedRepository(context);
            var service = new SchedService(repository);

            var fisioterapeuta = new Fisioterapeuta(Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64"), "Juan", "Perez 1", 10);
            var room = new(Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a"), "CAMILLA 1", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 1);

            var sched = new Sched
            (
                Guid.Parse("7b87ce3c-e801-4f82-9de5-5bd49fe50031"),
                Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64"),
                Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a"),
                6,
                fechaFormateada
            );

            var response = await service.AddSched(sched);
            Assert.True(response.Success);
            Assert.Equal("Sched creado correctamente", response.Message);

        }
    }
}
using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Xunit;

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
        public async Task InvalidDataFisio()
        {
            // Arrage
            AppDbContext context = CreateMemoryContext("InvalidDataFisio");
            
            // Act
            Fisioterapeuta fisio = new Fisioterapeuta(Guid.NewGuid(), "", "", 10);

            var result = await context.Fisioterapeutas.AddAsync(fisio);
            await context.SaveChangesAsync(); 

            // Assert
            Assert.Throws<ArgumentException>(() => result);
            
        }

    }
}
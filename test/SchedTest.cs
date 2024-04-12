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

        //TODO: Implementar pruebas unitarias para el método AddSched
        
    }
}
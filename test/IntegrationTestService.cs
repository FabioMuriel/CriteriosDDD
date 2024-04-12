using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;

namespace test
{
    public class IntegrationTestService
    {
        public IntegrationTestService()
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
        
        DateTime fecha = DateTime.Now;
        string fechaFormateada = fecha.ToString("yyyy/MM/dd");

        [Fact]
        public async Task IntegrationTestProcesoDeCitaCompleta()
        {
            var context = CreateMemoryContext("IntegrationTestProcesoDeCitaCompleta");

            var fisioterapeutaRepository = new FisioterapeutaRepository(context);
            var fisioterapeutaService = new FisioterapeutaService(fisioterapeutaRepository);

            var zonaRepository = new ZonaRepository(context);
            var zonaService = new ZonaService(zonaRepository);

            var roomsRepository = new RoomsRepository(context);
            var roomsService = new RoomsService(roomsRepository);

            var restriccionesRepository = new RestriccionesRepository(context);
            var restriccionesService = new RestriccionesService(restriccionesRepository);

            var schedRepository = new SchedRepository(context);
            var schedService = new SchedService(schedRepository);

            var fisioterapeuta = new Fisioterapeuta(Guid.NewGuid(), "Fisioterapeuta 1", "Apellido 1", 20);
            await fisioterapeutaService.AddFisioterapeuta(fisioterapeuta);

            var zona = new Zona(Guid.NewGuid(), "Zona 1", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10");
            await zonaService.AddZona(zona);

            var room = new Rooms(Guid.NewGuid(), "Room 1", zona.ZonaId, 1);
            await roomsService.AddRooms(room);

            var restricciones = new RestriccionesDeZonas(Guid.NewGuid(), "Restriccion 1", "1,2,3", "12,13,14", "Los fisioterapeutas ubicados en camillas 1, 2 y 3 solo pueden atender en manos 2, 3 y 4");
            await restriccionesService.AddRestriccionesDeZonas(restricciones);

            //Se debe construir la cita completa
            var sched = new Sched(Guid.NewGuid(), fisioterapeuta.FisioterapeutaId, room.RoomId, 6, fechaFormateada);
            await schedService.AddSched(sched);

            //TODO: Terminar de construir la cita completa 
            var scheds = await schedService.GetSched();

            Assert.True
            Assert.NotNull(scheds);

            //TODO: Agregar Validaciones de la cita completa, verificar todos los datos de la cita, deben ser correctos


        }


    }
}
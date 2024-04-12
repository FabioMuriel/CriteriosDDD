using CriteriosDominio.Dominio.Modelos.Entidades;
using Infrastructure.contexto;
using Microsoft.EntityFrameworkCore;
using Infrastructure.src.repository;
using CriteriosAplicaion.Services;
using CriteriosDominio.Dominio.Servicios;
using CriteriosDominio.Dominio.interfaces;

namespace test
{
    public class ValidadorDeRestriccionesDeZonasTest
    {
        public ValidadorDeRestriccionesDeZonasTest()
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
        public async Task RequestNullTest()
        {
            var context = CreateMemoryContext("RequestNullTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var response = await validador.ValidarRestricciones(null);

            Assert.False(response.Success);
            Assert.Contains("El Request no puede ser nulo", response.Errores);

        }

        [Fact]
        public async Task RequestRoomIdNullTest()
        {
            var context = CreateMemoryContext("RequestRoomIdNullTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = Guid.Empty,
                FisioterapeutaId = Guid.Empty,
                Hora = 6,
                Fecha = "2021-10-10"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.False(response.Success);
            Assert.Contains("El roomId no puede ser nulo", response.Errores);
            Assert.Contains("El fisioterapeutaId no puede ser nulo", response.Errores);

        }

        [Fact]
        public async Task RequestHoraInvalidaTest()
        {
            var context = CreateMemoryContext("RequestHoraInvalidaTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = Guid.NewGuid(),
                FisioterapeutaId = Guid.NewGuid(),
                Hora = 25,
                Fecha = "2021-10-10"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.False(response.Success);
            Assert.Contains("La hora no puede ser menor a 6 ni mayor a 18", response.Errores);

        }

        [Fact]
        public async Task RequestFechaInvalidaTest()
        {
            var context = CreateMemoryContext("RequestFechaInvalidaTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = Guid.NewGuid(),
                FisioterapeutaId = Guid.NewGuid(),
                Hora = 6,
                Fecha = "0"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.False(response.Success);
            Assert.Contains("La fecha es invalida", response.Errores);

        }

        [Fact]
        public async Task RequestValidTest()
        {
            var context = CreateMemoryContext("RequestValidTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = new Fisioterapeuta(Guid.Parse("6f1144ba-8fd5-41c0-a155-995bfe11b51c"), "Fisio", "Terapeuta", 10);
            var room = new Rooms(Guid.Parse("1606a033-42c5-44dd-99b9-99e2e97fadbe"), "Room 1", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 10);
            
            await fisioterapeutaRepository.AddFisioterapeuta(fisioterapeuta);
            await roomsRepository.AddRooms(room);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = room.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2025-10-10"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal(string.Empty, response.Mensaje);
        }

        [Fact]
        public async Task RequestValidMasterTest()
        {
            var context = CreateMemoryContext("RequestValidMasterTest");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = new Fisioterapeuta(Guid.Parse("6f1144ba-8fd5-41c0-a155-995bfe11b51c"), "Fisio", "Terapeuta", 30);
            var room = new Rooms(Guid.Parse("1606a033-42c5-44dd-99b9-99e2e97fadbe"), "Room 1", Guid.Parse("769c08df-3478-4b9f-b221-ed15de8d7365"), 10);
            
            await fisioterapeutaRepository.AddFisioterapeuta(fisioterapeuta);
            await roomsRepository.AddRooms(room);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = room.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2025-10-10"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal(string.Empty, response.Mensaje);
        }

        [Fact]
        public async Task Restriccion1Invalaid(){
            var context = CreateMemoryContext("Restriccion1Invalaid");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = fisioterapeutaRepository.GetFisioterapeutaById(Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64")).Result;
            var room = roomsRepository.GetRoomsById(Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a")).Result;
            var sched = new Sched(Guid.Parse("79015099-8131-4751-be39-c27621dcec3b"), fisioterapeuta.FisioterapeutaId, room.RoomId, 6, "2024-12-12");

            var roomDondeSeQuiereAgendar = roomsRepository.GetRoomsById(Guid.Parse("ed04bf65-bd66-4a53-8875-a14a5bf0e0a7")).Result;

            await schedRepository.AddSched(sched);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = roomDondeSeQuiereAgendar.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2024-12-12"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal("Los fisioterapeutas ubicados en camillas 1, 2 y 3 solo pueden atender en manos 2, 3 y 4", response.Mensaje);
        }

        [Fact]
        public async Task Restriccion1Valid(){
            var context = CreateMemoryContext("Restriccion1Valid");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = fisioterapeutaRepository.GetFisioterapeutaById(Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64")).Result;
            var room = roomsRepository.GetRoomsById(Guid.Parse("e584c1e6-23cd-4c55-a534-8620e433415a")).Result;
            var sched = new Sched(Guid.Parse("79015099-8131-4751-be39-c27621dcec3b"), fisioterapeuta.FisioterapeutaId, room.RoomId, 6, "2024-12-12");

            var roomDondeSeQuiereAgendar = roomsRepository.GetRoomsById(Guid.Parse("8f9be634-4864-475e-a08d-a94ec25b8d78")).Result;

            await schedRepository.AddSched(sched);

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = roomDondeSeQuiereAgendar.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2024-12-12"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal(string.Empty, response.Mensaje);
        }


        [Fact]
        public async Task Restriccion2Invalid(){
            var context = CreateMemoryContext("Restriccion2Invalid");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = fisioterapeutaRepository.GetFisioterapeutaById(Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64")).Result;
            var room = roomsRepository.GetRoomsById(Guid.Parse("5545323f-f2c7-4436-a06d-1184617eddaa")).Result;
            var sched = new Sched(Guid.Parse("79015099-8131-4751-be39-c27621dcec3b"), fisioterapeuta.FisioterapeutaId, room.RoomId, 6, "2024-12-12");

            await schedRepository.AddSched(sched);

            var roomDondeSeQuiereAgendar = roomsRepository.GetRoomsById(Guid.Parse("93126113-be52-4008-9d1e-90aee0e53a70")).Result;

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = roomDondeSeQuiereAgendar.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2024-12-12"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal("Los fisioterapeutas ubicados en camillas 4, 5 y 6 solo pueden atender en manos 5, 6 y 7", response.Mensaje);
        }

        [Fact]
        public async Task Restriccion2Valid(){
            var context = CreateMemoryContext("Restriccion2Valid");
            var restriccionesDeZonasRepository = new RestriccionesDeZonasRepository(context);
            var roomsRepository = new RoomsRepository(context);
            var schedRepository = new SchedRepository(context);
            var fisioterapeutaRepository = new FisioterapeutaRepository(context);

            var fisioterapeuta = fisioterapeutaRepository.GetFisioterapeutaById(Guid.Parse("cc4e89ef-4ee5-4388-a90f-2f646aeeaa64")).Result;
            var room = roomsRepository.GetRoomsById(Guid.Parse("5545323f-f2c7-4436-a06d-1184617eddaa")).Result;
            var sched = new Sched(Guid.Parse("79015099-8131-4751-be39-c27621dcec3b"), fisioterapeuta.FisioterapeutaId, room.RoomId, 6, "2024-12-12");

            await schedRepository.AddSched(sched);

            var roomDondeSeQuiereAgendar = roomsRepository.GetRoomsById(Guid.Parse("4d0a7834-0dc2-4bfb-8c7f-e4578c5d5fa3")).Result;

            ValidadorDeRestriccionesDeZonas validador = new ValidadorDeRestriccionesDeZonas(restriccionesDeZonasRepository, roomsRepository, schedRepository, fisioterapeutaRepository);

            var request = new ValidadorDeRestriccionesDeZonasRequest
            {
                RoomId = roomDondeSeQuiereAgendar.RoomId,
                FisioterapeutaId = fisioterapeuta.FisioterapeutaId,
                Hora = 6,
                Fecha = "2024-12-12"
            };

            var response = await validador.ValidarRestricciones(request);

            Assert.True(response.Success);
            Assert.Equal(string.Empty, response.Mensaje);
        }


    }
}
using CriteriosAplicaion.inerfaces;
using CriteriosAplicaion.Services;
using CriteriosAplication.services;
using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Servicios;
using Infrastructure.contexto;
using Infrastructure.src.repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add this line to register your in-memory database
        builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Asterisk"));

        //Repositories
        builder.Services.AddScoped<IFisioterapeutaRepository, FisioterapeutaRepository>();
        builder.Services.AddScoped<IFisioterapeutaService, FisioterapeutaService>();

        builder.Services.AddScoped<IRestriccionesDeZonasRepository, RestriccionesDeZonasRepository>();
        builder.Services.AddScoped<IRestriccionesDeZonasService, RestriccionesDeZonasService>();

        builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();
        builder.Services.AddScoped<IRoomsService, RoomsService>();

        builder.Services.AddScoped<ISchedRepository, SchedRepository>();
        builder.Services.AddScoped<ISchedService, SchedService>();

        builder.Services.AddScoped<IZonaRepository, ZonasRepository>();
        builder.Services.AddScoped<IZonaService, ZonaService>();

        builder.Services.AddScoped<IErrorFactory, ErrorFactory>();

        // Add services to the container.
        builder.Services.AddScoped<IPosicionDeAgendamientoValido, PosicionDeAgendamientoValido>();
        builder.Services.AddScoped<IValidadorDeRestriccionesDeZonas, ValidadorDeRestriccionesDeZonas>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

    }
}
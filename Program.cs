using CriteriosDominio.Dominio.Servicios;
using Infrastructure.src.interfaces;
using Infrastructure.src.repository;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IZonaRepository, ZonasRepository>();
        builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();
        builder.Services.AddScoped<IRestriccionesDeZonasRepository, RestriccionesDeZonasRepository>();
        builder.Services.AddScoped<IFisioterapeuta, FisioterapeutaRepository>();
        builder.Services.AddScoped<ValidadorDeRestriccionesDeZonas>();
        builder.Services.AddScoped<ISchedRepository, SchedRepository>();
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
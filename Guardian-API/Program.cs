using Guardian_API.Application.Interfaces;
using Guardian_API.Application.Services;
using Guardian_API.Domain.Interfaces;
using Guardian_API.Infrastructure.Data.AppData;
using Guardian_API.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=rm99708;Password=180105;");
});

builder.Services.AddScoped<IFalhaRepository, FalhaRepository>();
builder.Services.AddScoped<IFalhaApplicationService, FalhaApplicationService>();

builder.Services.AddScoped<IParqueRepository, ParqueRepository>();
builder.Services.AddScoped<IParqueApplicationService, ParqueApplicationService>();

builder.Services.AddScoped<IAerogeradorRepository, AerogeradorRepository>();
builder.Services.AddScoped<IAerogeradorApplicationService, AerogeradorApplicationService>();

builder.Services.AddScoped<ITorreRepository, TorreRepository>();
builder.Services.AddScoped<ITorreApplicationService, TorreApplicationService>();

builder.Services.AddSingleton<ClimaPredictionService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Guardian API",
        Version = "v1",
        Description = "Api para gerenciamento de Aerogeradores e Parques Eólicos"
    });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

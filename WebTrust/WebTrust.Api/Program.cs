using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebTrust.Domain.Entities;
using WebTrust.Infrastructure.GeneryRepository;
using WebTrust.Infrastructure.Persitence.Data;
using WebTrust.Infrastructure.Repository;
using WebTrust.Infrastructure.Repository.WebTrust.Infrastructure.Repositories;
using WebTrust.Infrastructure.Services;
using WebTrut.Application.Interfaces;
using WebTrut.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// === 1️⃣ Configurar CORS ===
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// === 2️⃣ Agregar servicios ===
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAnalisisRepository, AnalisisRepository>();
builder.Services.AddScoped<IHistorialAnalisisRepository, HistorialAnalisisRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<IAnalisisService, AnalisisService>();
builder.Services.AddScoped<IHistorialAnalisisService, HistorialAnalisisService>();
builder.Services.AddScoped<IAnalisisUrlService, AnalisisUrlService>();


var app = builder.Build();

// === 3️⃣ Configuración del pipeline ===
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();

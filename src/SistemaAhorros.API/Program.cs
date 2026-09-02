using SistemaAhorros.Domain;
using SistemaAhorros.Infrastructure.Repositories;
using SistemaAhorros.Application.Services;
using SistemaAhorros.Application.Servicios;
using SistemaAhorros.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios del contenedor de dependencias
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de Repositorios e Inyección de Dependencias
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

// Registro de Casos de Uso / Servicios de Aplicación
builder.Services.AddScoped<ConsultarBalanceService>();
builder.Services.AddScoped<DepositarUseCase>(); // Cambiado de DepositUseCase a DepositarUseCase

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

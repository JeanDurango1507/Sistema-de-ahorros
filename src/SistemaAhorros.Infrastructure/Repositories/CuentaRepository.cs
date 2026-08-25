using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaAhorros.Domain;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        // Creamos una lista en memoria con datos falsos de prueba
        private readonly List<Cuenta> _cuentasSimuladas;

        public CuentaRepository()
        {
            _cuentasSimuladas = new List<Cuenta>
            {
                // Cuenta 1: Saldo de $1,500.50
                new Cuenta { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), NumeroCuenta = "123456", Saldo = 1500.50m },
                // Cuenta 2: Saldo de $50.00
                new Cuenta { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), NumeroCuenta = "789012", Saldo = 50.00m }
            };
        }

        // Buscamos la cuenta por su ID en nuestra lista simulada
        public async Task<Cuenta?> ObtenerPorIdAsync(Guid id)
        {
            // Simulamos una respuesta asíncrona rápida
            await Task.Delay(10); 
            
            return _cuentasSimuladas.FirstOrDefault(c => c.Id == id);
        }
    }
}
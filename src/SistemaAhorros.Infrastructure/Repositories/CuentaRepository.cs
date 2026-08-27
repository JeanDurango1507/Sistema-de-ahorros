using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaAhorros.Domain;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // Creamos una lista en memoria con datos falsos de prueba
        private readonly List<Account> _simulatedAccounts;

        public AccountRepository()
        {
            _simulatedAccounts = new List<Account>
            {
                // Cuenta 1: Saldo de $1,500.50
                new Account { Id = Guid.Parse("1193078067"), AccountNumber = "123456", Balance = 1500.50m },
                // Cuenta 2: Saldo de $50.00
                new Account { Id = Guid.Parse("1193078066"), AccountNumber = "789012", Balance = 50.00m }
            };
        }

        // Buscamos la cuenta por su ID en nuestra lista simulada
        public async Task<Account?> GetByIdAsync(Guid id)
        {
            // Simulamos una respuesta asíncrona rápida
            await Task.Delay(10);

            return _simulatedAccounts.FirstOrDefault(account => account.Id == id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaAhorros.Domain;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _simulatedAccounts;

        public AccountRepository()
        {
            _simulatedAccounts = new List<Account>
            {
                new Account(1193078067, 1500.50m) { AccountNumber = "123456" },
                new Account(1193078066, 50.00m) { AccountNumber = "789012" }
            };
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            await Task.Delay(10);
            return _simulatedAccounts.FirstOrDefault(account => account.Id == id);
        }
    }
}
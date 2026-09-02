using SistemaAhorros.Domain;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories;

public class InMemoryAccountRepository : IAccountRepository
{
    private static readonly List<Account> _accounts = new()
    {
        new Account(1, "123456", 1000m, "Titular Principal")
    };

    public Account? GetById(int id)
    {
        return _accounts.FirstOrDefault(a => a.Id == id);
    }

    public Task<Account?> GetByIdAsync(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(account);
    }

    public Task<Account?> GetByAccountNumberAsync(string accountNumber)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        return Task.FromResult(account);
    }

    public void Update(Account account)
    {
        var index = _accounts.FindIndex(a => a.Id == account.Id);
        if (index != -1)
        {
            _accounts[index] = account;
        }
    }

    public Task UpdateAsync(Account account)
    {
        Update(account);
        return Task.CompletedTask;
    }
}
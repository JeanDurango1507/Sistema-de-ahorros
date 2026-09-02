using SistemaAhorros.Domain;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private static readonly List<Account> _cuentas = new()
    {
        new Account(1, "123456", 1000m, "Titular Principal"),
        new Account(2, "654321", 500m, "Titular Secundario")
    };

    public Account? GetById(int id)
    {
        return _cuentas.FirstOrDefault(c => c.Id == id);
    }

    public Task<Account?> GetByIdAsync(int id)
    {
        var cuenta = _cuentas.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(cuenta);
    }

    public void Update(Account account)
    {
        var index = _cuentas.FindIndex(c => c.Id == account.Id);
        if (index != -1)
        {
            _cuentas[index] = account;
        }
    }

    public Task UpdateAsync(Account account)
    {
        Update(account);
        return Task.CompletedTask;
    }
}
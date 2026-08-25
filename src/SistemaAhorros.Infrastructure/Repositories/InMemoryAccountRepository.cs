using System.Collections.Concurrent;
using SistemaAhorros.Application.Interfaces;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Infrastructure.Repositories;

public sealed class InMemoryAccountRepository : IAccountRepository
{
    private readonly ConcurrentDictionary<int, Account> accounts = new(
        new[] { new KeyValuePair<int, Account>(1, new Account(1, 100000m)) });

    public Account? GetById(int accountId)
    {
        accounts.TryGetValue(accountId, out Account? account);
        return account;
    }

    public void Update(Account account)
    {
        accounts[account.Id] = account;
    }
}
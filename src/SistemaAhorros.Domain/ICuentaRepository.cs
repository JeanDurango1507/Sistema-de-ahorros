using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Domain;

public interface IAccountRepository
{
    Account? GetById(int id);
    Task<Account?> GetByIdAsync(int id);
    void Update(Account account);
    Task UpdateAsync(Account account);
}
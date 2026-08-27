using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Application.Interfaces;

public interface IAccountRepository
{
    Account? GetById(int accountId);
    void Update(Account account);
}
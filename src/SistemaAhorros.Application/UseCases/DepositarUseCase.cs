using SistemaAhorros.Application.DTOs;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Application.UseCases;

public class DepositUseCase
{
    private static readonly List<Account> _accounts = new()
    {
        new Account("123456", 1000m)
    };

    public Account Execute(DepositDto dto)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == dto.AccountNumber);

        if (account == null)
        {
            throw new KeyNotFoundException($"Account number {dto.AccountNumber} was not found.");
        }

        account.Deposit(dto.Amount);
        return account;
    }
}
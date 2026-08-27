using SistemaAhorros.Application.DTOs;
using SistemaAhorros.Application.Interfaces;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Application.Services;

public sealed class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public WithdrawalResponse Withdraw(int accountId, WithdrawalRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (accountId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(accountId), "The identifier must be greater than zero.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.Amount), "The withdrawal amount must be greater than zero.");
        }

        Account account = accountRepository.GetById(accountId)
            ?? throw new KeyNotFoundException($"Account {accountId} does not exist.");

        account.Withdraw(request.Amount);
        accountRepository.Update(account);

        return new WithdrawalResponse(account.Id, request.Amount, account.Balance);
    }
}
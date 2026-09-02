using SistemaAhorros.Domain;
using SistemaAhorros.Application.DTOs;

namespace SistemaAhorros.Application.UseCases;

public class DepositarUseCase
{
    private readonly IAccountRepository _accountRepository;

    public DepositarUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<object> ExecuteAsync(DepositDto request)
    {
        var account = await _accountRepository.GetByIdAsync(request.AccountId);
        if (account == null)
        {
            throw new KeyNotFoundException($"La cuenta con ID {request.AccountId} no existe.");
        }

        account.Deposit(request.Amount);
        await _accountRepository.UpdateAsync(account);

        return new { AccountId = account.Id, NewBalance = account.Balance };
    }
}
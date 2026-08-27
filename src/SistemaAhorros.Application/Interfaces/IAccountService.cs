using SistemaAhorros.Application.DTOs;

namespace SistemaAhorros.Application.Interfaces;

public interface IAccountService
{
    WithdrawalResponse Withdraw(int accountId, WithdrawalRequest request);
}
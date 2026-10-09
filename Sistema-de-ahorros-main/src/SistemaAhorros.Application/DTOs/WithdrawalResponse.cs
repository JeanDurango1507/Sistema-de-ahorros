namespace SistemaAhorros.Application.DTOs;

public sealed record WithdrawalResponse(int AccountId, decimal WithdrawnAmount, decimal CurrentBalance);
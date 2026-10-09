namespace SistemaAhorros.Domain.Exceptions;

public sealed class InsufficientBalanceException : Exception
{
    public int AccountId { get; }
    public decimal AvailableBalance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientBalanceException(int accountId, decimal availableBalance, decimal requestedAmount)
        : base("The account balance is insufficient to complete the withdrawal.")
    {
        AccountId = accountId;
        AvailableBalance = availableBalance;
        RequestedAmount = requestedAmount;
    }
}
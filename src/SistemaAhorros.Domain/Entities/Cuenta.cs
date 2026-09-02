namespace SistemaAhorros.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Balance { get; private set; }
    public string AccountHolder { get; set; } = string.Empty;

    public Account()
    {
    }

    public Account(int id, string accountNumber, decimal initialBalance, string accountHolder)
    {
        Id = id;
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolder = accountHolder;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance.");

        Balance -= amount;
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}

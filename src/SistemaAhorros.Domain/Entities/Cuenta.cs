namespace SistemaAhorros.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Balance { get; private set; }

    public Account(string accountNumber, decimal initialBalance = 0)
    {
        Id = Guid.NewGuid();
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("The deposit amount must be greater than zero.");
        }

        Balance += amount;
    }
}
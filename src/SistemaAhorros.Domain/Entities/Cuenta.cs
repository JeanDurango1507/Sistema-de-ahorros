namespace SistemaAhorros.Domain.Entities;

public class Account
{
<<<<<<< HEAD
	public int Id { get; private set; }
	public decimal Balance { get; private set; }

	public Account(int id, decimal initialBalance)
	{
		if (id <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(id), "The identifier must be greater than zero.");
		}

		if (initialBalance < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(initialBalance), "The initial balance cannot be negative.");
		}

		Id = id;
		Balance = initialBalance;
	}

	public void Withdraw(decimal amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(amount), "The withdrawal amount must be greater than zero.");
		}

		if (amount > Balance)
		{
			throw new Exceptions.InsufficientBalanceException(Id, Balance, amount);
		}

		Balance -= amount;
	}
}
=======
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
>>>>>>> origin/main

namespace SistemaAhorros.Domain.Entities;

public class Account
{
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

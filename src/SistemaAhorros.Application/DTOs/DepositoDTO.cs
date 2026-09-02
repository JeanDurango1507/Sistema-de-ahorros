namespace SistemaAhorros.Application.DTOs;

public class DepositDto
{
    public int AccountId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
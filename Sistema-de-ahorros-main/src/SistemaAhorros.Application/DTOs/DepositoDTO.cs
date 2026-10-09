namespace SistemaAhorros.Application.DTOs;

public class DepositDto
{
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
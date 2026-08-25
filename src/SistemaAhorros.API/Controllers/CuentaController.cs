using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.DTOs;
using SistemaAhorros.Application.UseCases;

namespace SistemaAhorros.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly DepositUseCase _depositUseCase;

    public AccountController()
    {
        _depositUseCase = new DepositUseCase();
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositDto dto)
    {
        try
        {
            var updatedAccount = _depositUseCase.Execute(dto);
            return Ok(new
            {
                Message = "Deposit successfully executed.",
                AccountNumber = updatedAccount.AccountNumber,
                NewBalance = updatedAccount.Balance
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Error = "An internal server error occurred." });
        }
    }
}
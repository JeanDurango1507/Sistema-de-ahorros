using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.Servicios;

namespace SistemaAhorros.API.Controllers;

[ApiController]
[Route("api/cuentas")]
public class AccountsController : ControllerBase
{
    private readonly ConsultarBalanceService _balanceService;

    public AccountsController(ConsultarBalanceService balanceService)
    {
        _balanceService = balanceService;
    }

    [HttpGet("{id:int}/balance")]
    public async Task<IActionResult> GetBalance(int id)
    {
        try
        {
            var currentBalance = await _balanceService.ExecuteAsync(id);
            return Ok(new { accountId = id, balance = currentBalance });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}

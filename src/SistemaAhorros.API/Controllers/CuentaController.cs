using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.Services;
using SistemaAhorros.Application.Servicios;
using SistemaAhorros.Application.DTOs;
using SistemaAhorros.Application.UseCases;

namespace SistemaAhorros.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentaController : ControllerBase
{
    private readonly ConsultarBalanceService _consultarBalanceService;
    private readonly DepositarUseCase _depositarUseCase;
    // Si tienes un servicio para retirar, inyéctalo aquí (ejemplo: RetirarUseCase _retirarUseCase)

    public CuentaController(
        ConsultarBalanceService consultarBalanceService,
        DepositarUseCase depositarUseCase)
    {
        _consultarBalanceService = consultarBalanceService;
        _depositarUseCase = depositarUseCase;
    }

    [HttpGet("{id:int}/balance")]
    public async Task<IActionResult> GetBalance(int id)
    {
        try
        {
            var balance = await _consultarBalanceService.ExecuteAsync(id);
            return Ok(new { AccountId = id, Balance = balance });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] DepositDto request)
    {
        try
        {
            var result = await _depositarUseCase.ExecuteAsync(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpPost("{accountId:int}/retirar")]
    public async Task<IActionResult> Retirar(int accountId, [FromBody] object request)
    {
        // Pega aquí la lógica que tenías en AccountController para el retiro
        return Ok();
    }
}
<<<<<<< HEAD
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.Servicios;

namespace SistemaAhorros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Esto genera la ruta de internet: api/cuentas
    public class AccountsController : ControllerBase
    {
        private readonly ConsultarSaldoService _balanceService;

        // El constructor recibe el servicio que creamos en la capa de Aplicación
        public AccountsController(ConsultarSaldoService balanceService)
        {
            _balanceService = balanceService;
        }

        // Endpoint GET: api/cuentas/{id}/saldo
        [HttpGet("{id}/balance")]
        public async Task<IActionResult> GetBalance(Guid id)
        {
            try
            {
                var currentBalance = await _balanceService.EjecutarAsync(id);

                // Si todo sale bien, devolvemos el saldo en formato JSON
                return Ok(new { accountId = id, balance = currentBalance });
            }
            catch (Exception ex)
            {
                // Si la cuenta no existe o hay un error, devolvemos un mensaje de error
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
=======
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
>>>>>>> origin/main

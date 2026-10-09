using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.DTOs;
using SistemaAhorros.Application.Interfaces;
using SistemaAhorros.Domain.Exceptions;

namespace SistemaAhorros.API.Controllers;

[ApiController]
[Route("api/account")]
public sealed class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("{accountId:int}/withdraw")]
    [ProducesResponseType(typeof(WithdrawalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<WithdrawalResponse> Withdraw(int accountId, [FromBody] WithdrawalRequest request)
    {
        try
        {
            return Ok(accountService.Withdraw(accountId, request));
        }
        catch (ArgumentOutOfRangeException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { message = exception.Message });
        }
        catch (InsufficientBalanceException exception)
        {
            return UnprocessableEntity(new
            {
                message = exception.Message,
                availableBalance = exception.AvailableBalance,
                requestedAmount = exception.RequestedAmount
            });
        }
    }
}
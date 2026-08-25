using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAhorros.Application.Servicios;

namespace SistemaAhorros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Esto genera la ruta de internet: api/cuentas
    public class CuentasController : ControllerBase
    {
        private readonly ConsultarSaldoService _saldoService;

        // El constructor recibe el servicio que creamos en la capa de Aplicación
        public CuentasController(ConsultarSaldoService saldoService)
        {
            _saldoService = saldoService;
        }

        // Endpoint GET: api/cuentas/{id}/saldo
        [HttpGet("{id}/saldo")]
        public async Task<IActionResult> ObtenerSaldo(Guid id)
        {
            try
            {
                var saldoActual = await _saldoService.EjecutarAsync(id);
                
                // Si todo sale bien, devolvemos el saldo en formato JSON
                return Ok(new { cuentaId = id, saldo = saldoActual });
            }
            catch (Exception ex)
            {
                // Si la cuenta no existe o hay un error, devolvemos un mensaje de error
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}

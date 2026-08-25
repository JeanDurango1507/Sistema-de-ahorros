using System;
using System.Threading.Tasks;
using SistemaAhorros.Domain;

namespace SistemaAhorros.Application.Servicios
{
    public class ConsultarSaldoService
    {
        private readonly ICuentaRepository _cuentaRepository;

        // Inyectamos el contrato del repositorio de la capa de Dominio
        public ConsultarSaldoService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        // Método que ejecuta la lógica para obtener el saldo
        public async Task<decimal> EjecutarAsync(Guid cuentaId)
        {
            var cuenta = await _cuentaRepository.ObtenerPorIdAsync(cuentaId);
            
            if (cuenta == null)
            {
                // Si la cuenta no existe en el sistema, lanzamos una alerta
                throw new Exception("La cuenta solicitada no existe.");
            }

            // Devolvemos el saldo actual de la cuenta
            return cuenta.Saldo;
        }
    }
}
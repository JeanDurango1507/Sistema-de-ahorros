using System;
using System.Threading.Tasks;
using SistemaAhorros.Domain;

namespace SistemaAhorros.Application.Servicios
{
    public class ConsultarBalanceService
    {
        private readonly IAccountRepository _accountRepository;

        // Inyectamos el contrato del repositorio de la capa de Dominio
        public ConsultarBalanceService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Método que ejecuta la lógica para obtener el saldo
        public async Task<decimal> ExecuteAsync(Guid accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
            {
                // Si la cuenta no existe en el sistema, lanzamos una alerta
                throw new Exception("The requested account does not exist.");
            }

            // Devolvemos el saldo actual de la cuenta
            return account.Balance;
        }
    }
}
using System;
using System.Threading.Tasks;
using SistemaAhorros.Domain;

namespace SistemaAhorros.Application.Servicios
{
    public class ConsultarBalanceService
    {
        private readonly IAccountRepository _accountRepository;

        public ConsultarBalanceService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<decimal> ExecuteAsync(int accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account == null)
            {
                throw new Exception("The requested account does not exist.");
            }

            return account.Balance;
        }
    }
}
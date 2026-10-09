using System.Threading.Tasks;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Domain
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(int id);
    }
}
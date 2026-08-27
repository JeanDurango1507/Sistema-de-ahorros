using System;
using System.Threading.Tasks;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Domain
{
    public interface IAccountRepository
    {
        // Esta tarea promete que podremos buscar una Cuenta usando su ID
        Task<Account?> GetByIdAsync(Guid id);
    }
}
using System;
using System.Threading.Tasks;
using SistemaAhorros.Domain.Entities;

namespace SistemaAhorros.Domain
{
    public interface ICuentaRepository
    {
        // Esta tarea promete que podremos buscar una Cuenta usando su ID
        Task<Cuenta?> ObtenerPorIdAsync(Guid id);
    }
}
using System;

namespace SistemaAhorros.Domain.Entities
{
    public class Cuenta
    {
        public Guid Id { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
    }
}
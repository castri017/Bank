using BlueBankApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class CuentaAhorros : BaseEntity
    { 
        public string IdentificacionPersona { get; set; }
        public string NumeroCuenta { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}

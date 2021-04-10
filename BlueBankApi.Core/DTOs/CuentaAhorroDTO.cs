using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Core.DTOs
{
    public class CuentaAhorroDTO
    {
        public int IdentificacionPersona { get; set; }
        public int NumeroCuenta { get; set; }
        public double Monto { get; set; } 
    }
}

using BlueBankApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class Transacciones : BaseEntity
    { 
        public string NumeroCuenta { get; set; }
        public double  Monto { get; set; }
        public int  IdTipoTransaccion { get; set; }
        public DateTime? FechaTransaccion { get; set; }
    }
}

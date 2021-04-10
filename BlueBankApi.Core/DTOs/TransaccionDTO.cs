using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Core.DTOs
{
    public  class TransaccionDTO
    {
        public int  NumeroCuenta { get; set; }
        public double  Monto { get; set; }
        public int  IdTipoTransaccion { get; set; } 
    }
}

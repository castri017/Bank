using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Interfaces
{
    public interface ICuentaAhorroServices
    {
        Task<CuentaAhorros> GetCuentaAhorros(string numeroCuenta);
        Task InsertCuentaAhorros(CuentaAhorros cuentaAhorros);

        Task<bool> updateCuentaAhorros(int numeroCuenta, double monto, int tipoTransaccion);
    }
}

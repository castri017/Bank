using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Infrastructure.Repositories
{
    public class CuentaAhorroRepository : ICuentaAhorroRepository
    {
        private readonly BlueBankContext _context;

        public CuentaAhorroRepository(BlueBankContext context)
        {
            _context = context;
        }


        public async Task<CuentaAhorros> GetCuentaAhorros(string numeroCuenta)
        {
            var transacciones = await _context.CuentaAhorros.FirstOrDefaultAsync(x => x.NumeroCuenta == numeroCuenta);
            return transacciones;
        }

        public async Task InsertCuentaAhorros(CuentaAhorros cuentaAhorros)
        {
            _context.CuentaAhorros.Add(cuentaAhorros);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCuentaAhorros(string numeroCuenta, double monto, int tipoTransaccion)
        {
            var cuenta = await GetCuentaAhorros(numeroCuenta); 
            if (tipoTransaccion == 1) {
                cuenta.Monto = cuenta.Monto + monto;
            }
            else{
                cuenta.Monto = cuenta.Monto - monto;
            }  
            int rows = await _context.SaveChangesAsync();
            return rows > 0; 
        }
         
    }
}

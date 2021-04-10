using BlueBankApi.Core.Exceptions;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Services
{
    public class CuentaAhorroServices : ICuentaAhorroServices
    {
        private readonly ICuentaAhorroRepository _cuentaAhorroRepository;

        public CuentaAhorroServices(ICuentaAhorroRepository cuentaAhorroRepository)
        {
            _cuentaAhorroRepository = cuentaAhorroRepository;
        }

        public async Task<CuentaAhorros> GetCuentaAhorros(string numeroCuenta)
        {
            return await _cuentaAhorroRepository.GetCuentaAhorros(numeroCuenta);
        }

        public async Task InsertCuentaAhorros(CuentaAhorros cuentaAhorros)
        {
             
            var cuenta = await _cuentaAhorroRepository.GetCuentaAhorros(cuentaAhorros.NumeroCuenta);
            if (cuenta != null)
            {
                throw new BusinessException("La cuenta ya existe");
            }
            else
            {
                CuentaAhorros cuentaAhorro = new CuentaAhorros();
                cuentaAhorro.IdentificacionPersona = cuentaAhorros.IdentificacionPersona;
                cuentaAhorro.NumeroCuenta = cuentaAhorros.NumeroCuenta;
                cuentaAhorro.Monto = cuentaAhorros.Monto;
                cuentaAhorro.FechaCreacion = DateTime.Now;

                await _cuentaAhorroRepository.InsertCuentaAhorros(cuentaAhorro);
            }

        }

        public Task<bool> updateCuentaAhorros(int numeroCuenta, double monto, int tipoTransaccion)
        {
            throw new NotImplementedException();
        }
    }
}

using BlueBankApi.Core.Exceptions;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Services
{
    public class TransaccionServices : ITransaccionServices
    {

        private readonly ICuentaAhorroRepository _cuentaAhorroRepository;
        private readonly ITransacionRepository _transacionRepository;

        public TransaccionServices(ICuentaAhorroRepository cuentaAhorroRepository, ITransacionRepository transacionRepository)
        {
            _cuentaAhorroRepository = cuentaAhorroRepository;
            _transacionRepository = transacionRepository;
        }

        public async Task<Transacciones> GetTransacciones(string numeroCuenta)
        {
            return await _transacionRepository.GetTransacciones(numeroCuenta);
        }

        public async Task InsertTransaccion(Transacciones transacciones)
        {
            var cuenta = await _cuentaAhorroRepository.GetCuentaAhorros(transacciones.NumeroCuenta);
            if (cuenta == null)
            {
                throw new BusinessException("La cuenta de ahorros no existe");
            }
            else if (transacciones.IdTipoTransaccion == 2 && transacciones.Monto > cuenta.Monto)
            {
                throw new BusinessException("El monto a retirar supera el valor  que se tiene en la cuenta");
            }
            else {
                Transacciones transaccion = new Transacciones();
                transaccion.NumeroCuenta = transacciones.NumeroCuenta;
                transaccion.Monto = transacciones.Monto;
                transaccion.IdTipoTransaccion = transacciones.IdTipoTransaccion;
                transaccion.FechaTransaccion = DateTime.Now;

                await _cuentaAhorroRepository.UpdateCuentaAhorros(transaccion.NumeroCuenta, Convert.ToDouble(transaccion.Monto), Convert.ToInt32(transaccion.IdTipoTransaccion));
                await _transacionRepository.InsertTransaccion(transaccion);
            }
        }
    }
}

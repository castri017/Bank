using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Infrastructure.Repositories
{
    public class TransaccionRepository : ITransacionRepository
    {
        private readonly BlueBankContext _context;

        public TransaccionRepository(BlueBankContext context)
        {
            _context = context;
        }


        public async Task<Transacciones> GetTransacciones(string numeroCuenta)
        {
            var transacciones = await _context.Transacciones.FirstOrDefaultAsync(x => x.NumeroCuenta == numeroCuenta);
            return transacciones;
        }

        public async Task InsertTransaccion(Transacciones transacciones)
        {
            _context.Transacciones.Add(transacciones);
            await _context.SaveChangesAsync();
        }
    }

}

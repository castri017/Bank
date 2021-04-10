using BlueBankApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Interfaces
{
    public interface ITransacionRepository
    { 
        Task<Transacciones> GetTransacciones(string numeroCuenta);
        Task InsertTransaccion(Transacciones transacciones);       

    }
}

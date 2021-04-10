using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Personas> GetPersonas(string identificacion);
        Task InsertPersona(Personas persona);
    }
}

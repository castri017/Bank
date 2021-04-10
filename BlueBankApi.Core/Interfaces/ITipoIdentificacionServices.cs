using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Interfaces
{
    public interface ITipoIdentificacionServices
    { 
        Task<IEnumerable<TipoIdentificacion>> GetTipoIdentificacion(); 
    }
}

using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Interfaces
{
    public interface ITipoIdentificacionRepository
    {
        Task<IEnumerable<TipoIdentificacion>> GetTipoIdentificacion();
    }
}

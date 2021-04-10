using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Services
{
    public class TipoIdentificacionServices : ITipoIdentificacionServices
    {
        private readonly ITipoIdentificacionRepository _identificaicionRepository; 

        public TipoIdentificacionServices(ITipoIdentificacionRepository identificaicionRepository)
        {
            _identificaicionRepository = identificaicionRepository; 
        }

        public async Task<IEnumerable<TipoIdentificacion>> GetTipoIdentificacion()
        {
            return await _identificaicionRepository.GetTipoIdentificacion();
        }
    } 
}

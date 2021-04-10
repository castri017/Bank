using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Infrastructure.Repositories
{
    public class TipoIdentificacionRepository : ITipoIdentificacionRepository
    {
        private readonly BlueBankContext _context;

        public TipoIdentificacionRepository(BlueBankContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TipoIdentificacion>> GetTipoIdentificacion()
        {
            var tipoIdentificacion = await _context.TipoIdentificacion.ToListAsync();
            return tipoIdentificacion;
        }
    }
}

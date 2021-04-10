using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBankApi.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly BlueBankContext _context;

        public PersonaRepository(BlueBankContext context)
        {
            _context = context;
        }

        public async Task<Personas> GetPersonas(string identificacion)
        {
            var personas = await _context.Personas.FirstOrDefaultAsync(x => x.Identificacion == identificacion);
            return personas;
        }

        public async Task InsertPersona(Personas persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }
    }
}

using BlueBankApi.Core.Exceptions;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace BlueBankApi.Core.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaServices(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository; 
        }


        public async Task<Personas> GetPersonas(string identificacion)
        {
            return await _personaRepository.GetPersonas(identificacion);
        }

        public async Task InsertPersona(Personas persona)
        {
            var per = await _personaRepository.GetPersonas(persona.Identificacion);
            if (per != null)
            {
                throw new BusinessException("El cliente ya existe");
            }
            else {
                Personas personas = new Personas();
                personas.Identificacion = persona.Identificacion;
                personas.Nombre = persona.Nombre;
                personas.Apellido = persona.Apellido;
                personas.IdTipoIdentificacion = persona.IdTipoIdentificacion;
                personas.FechaNacimeinto = persona.FechaNacimeinto;
                personas.Movil = persona.Movil;
                persona.FechaIngreso = DateTime.Now;

                await _personaRepository.InsertPersona(personas);
            }
        }
    }
}

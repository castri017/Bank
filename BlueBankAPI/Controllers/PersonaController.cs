using AutoMapper;
using BlueBankApi.Core.DTOs;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using BlueBankAPI.Responses;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueBankAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaServices _personaServices;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaServices personaServices, IMapper mapper)
        {
            _personaServices = personaServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonas(string identificacion)
        {
            var persona = await _personaServices.GetPersonas(identificacion);
            var personaDto = _mapper.Map<PersonaDTO>(persona);
            var response = new ApiResponse<PersonaDTO>(personaDto);
            return Ok(response);
        }

        [HttpPost("GuardarPersona")]
        public async Task<IActionResult> Post(PersonaDTO personaDto)
        {
            var persona = _mapper.Map<Personas>(personaDto);
            await _personaServices.InsertPersona(persona);
            var response = new ApiResponse<PersonaDTO>(personaDto);
            return Ok(response);
        }
    }
}

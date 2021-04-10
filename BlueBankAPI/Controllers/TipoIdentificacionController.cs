using AutoMapper;
using BlueBankApi.Core.DTOs;
using BlueBankApi.Core.Interfaces;
using BlueBankAPI.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {

        private readonly ITipoIdentificacionServices _tipoidentificacionServices;
        private readonly IMapper _mapper;

        public TipoIdentificacionController(ITipoIdentificacionServices tipoidentificacionServices, IMapper mapper)
        {
            _tipoidentificacionServices = tipoidentificacionServices;
            _mapper = mapper;
        }

        [HttpGet("ListarTipoIdentificacion")]
        public async Task<IActionResult> GetBodega()
        {
            var tipoIdentificacion = await _tipoidentificacionServices.GetTipoIdentificacion();
            var tipoIdentificacionDto = _mapper.Map<IEnumerable<TipoIdentificacionDTO>>(tipoIdentificacion);
            var response = new ApiResponse<IEnumerable<TipoIdentificacionDTO>>(tipoIdentificacionDto);
            return Ok(response);
        }
    }
}

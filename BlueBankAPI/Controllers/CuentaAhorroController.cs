using AutoMapper;
using BlueBankApi.Core.DTOs;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Core.Services;
using BlueBankApi.Infrastructure.Data;
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
    public class CuentaAhorroController : ControllerBase
    {
        private readonly ICuentaAhorroServices _cuentaAhorroServices;
        private readonly IMapper _mapper;

        public CuentaAhorroController(ICuentaAhorroServices cuentaAhorroService, IMapper mapper)
        {
            _cuentaAhorroServices = cuentaAhorroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuentaAhorros(string numeroCuenta)
        {
            var cuenta = await _cuentaAhorroServices.GetCuentaAhorros(numeroCuenta);
            var cuentaDto = _mapper.Map<CuentaAhorroDTO>(cuenta);
            var response = new ApiResponse<CuentaAhorroDTO>(cuentaDto);
            return Ok(response);
        }

        [HttpPost("GuardarCuentaAhorro")]
        public async Task<IActionResult> Post(CuentaAhorroDTO cuentaDto)
        {
            var cuenta = _mapper.Map<CuentaAhorros>(cuentaDto);
            await _cuentaAhorroServices.InsertCuentaAhorros(cuenta);
            var response = new ApiResponse<CuentaAhorroDTO>(cuentaDto);
            return Ok(response);
        }
    }
}
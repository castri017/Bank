using AutoMapper;
using BlueBankApi.Core.DTOs;
using BlueBankApi.Core.Interfaces;
using BlueBankApi.Infrastructure.Data;
using BlueBankAPI.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BlueBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionServices _transaccionServices;
        private readonly IMapper _mapper;

        public TransaccionController(ITransaccionServices transaccionServices, IMapper mapper)
        {
            _transaccionServices = transaccionServices;
            _mapper = mapper;
        }
 

        [HttpGet] 
        public async Task<IActionResult> GetTransacciones(string numeroCuenta)
        {
            var transaccion = await _transaccionServices.GetTransacciones(numeroCuenta);
            var transaccionDto = _mapper.Map<TransaccionDTO>(transaccion);
            var response = new ApiResponse<TransaccionDTO>(transaccionDto);
            return Ok(response);
        }

        [HttpPost("GuardarTransaccion")]
        public async Task<IActionResult> Post(TransaccionDTO transaccionDto)
        {
            var transaccion = _mapper.Map<Transacciones>(transaccionDto);
            await _transaccionServices.InsertTransaccion(transaccion);
            var response = new ApiResponse<TransaccionDTO>(transaccionDto);
            return Ok(response);
        }
    }
}
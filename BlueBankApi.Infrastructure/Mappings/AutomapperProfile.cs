using AutoMapper;
using BlueBankApi.Core.DTOs;
using BlueBankApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Personas, PersonaDTO>();
            CreateMap<PersonaDTO, Personas>();
            CreateMap<CuentaAhorros, CuentaAhorroDTO>();
            CreateMap<CuentaAhorroDTO, CuentaAhorros>();
            CreateMap<Transacciones, TransaccionDTO>();
            CreateMap<TransaccionDTO, Transacciones>();
            CreateMap<TipoIdentificacionDTO, TipoIdentificacion>();
            CreateMap<TipoIdentificacion, TipoIdentificacionDTO>();

        }
    }

}

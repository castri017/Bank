using BlueBankApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class TipoIdentificacion : BaseEntity
    { 
        public string Descripcion { get; set; }
    }
}

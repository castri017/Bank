using BlueBankApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class TipoTransacion : BaseEntity
    { 
        public string Descripcion { get; set; }
    }
}

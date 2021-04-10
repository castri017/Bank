using System;
using System.Collections.Generic;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class Personas
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int  IdTipoIdentificacion { get; set; }
        public DateTime? FechaNacimeinto { get; set; }
        public string Movil { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}

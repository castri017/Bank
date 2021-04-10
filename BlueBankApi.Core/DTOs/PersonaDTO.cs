using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Core.DTOs
{
    public class PersonaDTO
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int  IdTipoIdentificacion { get; set; }
        public DateTime? FechaNacimeinto { get; set; }
        public string Movil { get; set; } 
    }
}

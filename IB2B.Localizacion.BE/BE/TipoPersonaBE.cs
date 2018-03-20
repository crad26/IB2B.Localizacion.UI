using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class TipoPersonaBE
    {
        
        public string TipoPersonaID { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Tipo Persona")]
        public string TipoPersonaNombre { get; set; }
    }
}

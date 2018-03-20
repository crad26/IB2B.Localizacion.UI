using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class TipoDocumentoBE
    {
        public String TipoDocumentoID { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Tipo de Documento.")]
        public string TipoDocumentoNombre { get; set; }

    }
}

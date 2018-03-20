using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class TipoMovimientoBE
    {
        public int IDTipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public CuentaBE OCuenta { get; set; }
        
        public string tipo { get; set; }
        public TipoOperacionBE oTipoOperacion { get; set; } 
        public string MotivoTraslado { get; set; }
        public TipoDocumentoBE oTipoDocumento { get; set; }
        public int IDSitioPredeterminado { get; set; }
       

    }
}


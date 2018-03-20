using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class ConfigLocalizacionBE
    {
        public TipoDocumentoBE oTipoDocumento { get; set; }
        public string IDDocumento { get; set; }
        public string ChequeraIntermedia { get; set; }
        public int MontoBase { get; set; }
        public string PrefijoCobroRetencion { get; set; }
        public string PrefijoPagoRetencion { get; set; }


        public string  BDIntermedia { get; set; }
        public string ClaseContAnalitica { get; set; }
        public string VersionDynamicsGP { get; set; }
        public string BDDynamic { get; set; }

        public int NumeroDecimalSpot { get; set; }
        public int IDBancoNacion { get; set; }
        public string NombreNacion { get; set; }
        public string PrefijoCobroDetraccion { get; set; }
        public string PrefijoPagoDetraccion { get; set; }
        

    }
}

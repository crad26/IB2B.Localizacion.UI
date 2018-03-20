using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{  
    [Serializable]
    public class ClienteBE
    {
        public ClienteBE()
        {
            this.oTipoDocumentoBE = new TipoDocumentoBE();
            this.oTipoPersonaBE = new TipoPersonaBE();
        }

        
        public string CUSTNMBR { get; set; }
       

        public string CUSTNAME { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Tipo de Documento.")]

        public TipoPersonaBE oTipoPersonaBE { get; set; }

        
        public TipoDocumentoBE oTipoDocumentoBE { get; set; }
        public string FRSTNAME { get; set; }
        public string SHRTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string MIDLNAME { get; set; }
        public string TB_NRO_DOCUMENTO { get; set; }
        public string TB_REFERENCIA { get; set; }
        public string TB_RAZON_SOCIAL { get; set; }
        public bool CB_BC { get; set; }
        public DateTime? DT_BC_FECHA1 { get; set; }
        public bool CB_AR { get; set; }
        public DateTime? DT_AR_FECHA1 { get; set; }
        public bool CB_AP { get; set; }
        public DateTime? DT_AP_FECHA1 { get; set; }
        public bool CB_RI { get; set; }
        public DateTime? DT_RI_FECHA1 { get; set; }
        public bool CB_NH { get; set; }
        public DateTime? DT_NH_FECHA1 { get; set; }
        public string Url_Detalle { get; set; }
    }
}

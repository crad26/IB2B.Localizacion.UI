using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    [Serializable]
    public class ProveedorBE
    {
        public ProveedorBE()
        {
            this.oTipoBienesBE = new TipoBienesBE();
            this.oTipoConvenioBE = new TipoConvenioBE();
            this.oTipoDocumentoBE = new TipoDocumentoBE();
            this.oTipoPersonaBE = new TipoPersonaBE();
            this.oTipoRentaBE = new TipoRentaBE();
        }
        [Required(ErrorMessage = "Debe ingresar el Id. Proveedor.")]
        public string VENDORID { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Proveedor.")]
        public string VENDNAME { get; set; }
        public TipoPersonaBE oTipoPersonaBE { get; set; }
        public TipoDocumentoBE oTipoDocumentoBE { get; set; }
        public TipoBienesBE oTipoBienesBE { get; set; }
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
        public TipoConvenioBE oTipoConvenioBE { get; set; }
        public TipoRentaBE oTipoRentaBE { get; set; }
        public bool CB_EA { get; set; }
        public String Url_Detalle { get; set; }
    }
}

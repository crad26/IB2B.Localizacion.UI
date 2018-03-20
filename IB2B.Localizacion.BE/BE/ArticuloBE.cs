using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    [Serializable]
    public class ArticuloBE
    {
        public ArticuloBE()
        {
            this.oCategoriaBE = new CategoriaBE();
            this.oArticuloControladoBE = new ArticuloControladoBE();
        }
        [Required(ErrorMessage = "Debe ingresar el Id. Artículo.")]
        public string ITEMNMBR { get; set; }
        [Required(ErrorMessage = "Debe ingresar la descripción.")]
        public string ITEMDESC { get; set; }
        public string UOMSCHDL { get; set; }
        public String ITMTRKOP { get; set; }
        public CategoriaBE oCategoriaBE { get; set; }
        public ArticuloControladoBE oArticuloControladoBE { get; set; }
        public Decimal? C_DETRACCION_PRCNT { get; set; }
        public bool CB_DRAWBACK { get; set; }
        public bool CB_CONTROL { get; set; }
        public bool CB_COMMODITY { get; set; }
        public bool CB_TRANSFORMA { get; set; }
        public int? TB_TOLERA_DIAS { get; set; }
        public int? TB_TOLERA_CANT { get; set; }
        public bool CB_ENVASE1 { get; set; }
        public bool CB_ENVASE2 { get; set; }
        public String Url_Detalle { get; set; }
    }
}

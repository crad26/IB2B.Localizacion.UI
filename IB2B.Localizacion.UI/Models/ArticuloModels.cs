using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class ArticuloModels
    {
        public ArticuloModels()
        {
            this.oComunBE = new ComunBE();
            this.oArticuloBE = new ArticuloBE();
            this.vLCategoriaBE = new List<CategoriaBE>();
            this.vLArticuloControladoBE = new List<ArticuloControladoBE>();
        }
        public ComunBE oComunBE { get; set; }
        public ArticuloBE oArticuloBE { get; set; }
        public List<CategoriaBE> vLCategoriaBE { get; set; }
        public List<ArticuloControladoBE> vLArticuloControladoBE { get; set; }
    }
}
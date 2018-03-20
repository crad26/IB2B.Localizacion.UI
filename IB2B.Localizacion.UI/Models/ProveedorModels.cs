using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class ProveedorModels
    {
        public ProveedorModels()
        {
            this.oComunBE = new ComunBE();
            this.oProveedorBE = new ProveedorBE();
            this.vLTipoBienesBE = new List<TipoBienesBE>();
            this.vLTipoConvenioBE = new List<TipoConvenioBE>();
            this.vLTipoRentaBE = new List<TipoRentaBE>();
            this.vLTipoPersonaBE = new List<TipoPersonaBE>();
            this.vLTipoDocumentoBE = new List<TipoDocumentoBE>();
        }
        public ComunBE oComunBE { get; set; }
        public ProveedorBE oProveedorBE { get; set; }
        public List<TipoBienesBE> vLTipoBienesBE { get; set; }
        public List<TipoConvenioBE> vLTipoConvenioBE { get; set; }
        public List<TipoRentaBE> vLTipoRentaBE { get; set; }
        public List<TipoPersonaBE> vLTipoPersonaBE { get; set; }
        public List<TipoDocumentoBE> vLTipoDocumentoBE { get; set; }
    }
}
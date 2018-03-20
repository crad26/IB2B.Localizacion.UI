using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class PagoMasivoModels
    {
        public PagoMasivoModels()
        {
            this.oComunBE = new ComunBE();
            this.oPagoMasivoBE = new PagoMasivoBE();
            this.vLChequeraBE = new List<ChequeraBE>();
            this.vLMonedaBE = new List<MonedaBE>();
            this.vLTipoOperacionBE = new List<TipoOperacionBE>();
            this.vLTipoPagoBE = new List<TipoPagoBE>();
        }
        public ComunBE oComunBE { get; set; }
        public PagoMasivoBE oPagoMasivoBE { get; set; }
        public List<TipoOperacionBE> vLTipoOperacionBE { get; set; }
        public List<TipoPagoBE> vLTipoPagoBE { get; set; }
        public List<ChequeraBE> vLChequeraBE { get; set; }
        public List<MonedaBE> vLMonedaBE { get; set; }
    }
}
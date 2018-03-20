using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IB2B.Localizacion.BE.BE;

namespace IB2B.Localizacion.UI.Models
{
    public class PagoDetraccionModel
    {
        public PagoDetraccionModel ()
        {
            this.oComunBE = new ComunBE();
            this.oChequera = new ChequeraBE();
            this.VLTipoOperacion = new List<TipoOperacionBE>();
            this.VLTipoPago = new List<TipoPagoBE>();
        }

        public ComunBE oComunBE { get; set; }
        public ChequeraBE oChequera { get; set; }

        public PagoDetraccionBE oPagoDetraccionBE { get; set; }
        public List<TipoOperacionBE> VLTipoOperacion { get; set; }
        public List<TipoPagoBE> VLTipoPago { get; set; }



    }
}
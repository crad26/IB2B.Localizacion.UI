using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class TipoConfiguracionModel
    {
        public TipoConfiguracionModel()
        {
            this.oComunBE = new ComunBE();
            this.oTipoOperacionBanco = new TipoOperacionBancoBE();
            this.ObOperacionBancoBE = new OperacionBancoBE();
        //    this.ObPago_Cobro = new TipoPago_CobroBE();
            this.VLPago_Cobro = new List<TipoPago_CobroBE>();
        }

        public ComunBE oComunBE { get; set; }
        public TipoOperacionBancoBE oTipoOperacionBanco { get; set; }
        public OperacionBancoBE ObOperacionBancoBE { get; set; }
       // public TipoPago_CobroBE ObPago_Cobro { get; set; }
        public List<TipoPago_CobroBE> VLPago_Cobro { get; set; }
    }
}
using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class TipoMovimientoModel
    {
        public TipoMovimientoModel()
        {
            this.oComunBE = new ComunBE();
            this.TipoMovimientoBE = new TipoMovimientoBE();
            this.CuentaBE = new CuentaBE();
            this.TipoOperacionBE = new TipoOperacionBE();
            this.TipoDocumentoBE = new TipoDocumentoBE();
        }
        public ComunBE oComunBE { get; set; }
        public TipoMovimientoBE TipoMovimientoBE { get; set; }
        public CuentaBE CuentaBE { get; set; }
        public TipoOperacionBE TipoOperacionBE { get; set; }
        public TipoDocumentoBE TipoDocumentoBE { get; set; }


        public List<TipoOperacionBE> VLTipoOperacion { get; set; }
    }
}
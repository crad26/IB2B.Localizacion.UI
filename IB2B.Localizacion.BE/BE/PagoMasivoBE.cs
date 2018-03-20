using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class PagoMasivoBE
    {
        public PagoMasivoBE()
        {
            this.oChequeraBE = new ChequeraBE();
            this.oMonedaBE = new MonedaBE();
            this.oTipoOperacionBE = new TipoOperacionBE();
            this.oTipoPagoBE = new TipoPagoBE();
            this.oCompaniaBE = new CompaniaBE();
        }
        public String NumeroOperacion { get; set; }
        public String NumeroPagoAsignado { get; set; }
        public String NumeroLote { get; set; }
        public DateTime FechaDocumento { get; set; }
        public TipoOperacionBE oTipoOperacionBE { get; set; }
        public TipoPagoBE oTipoPagoBE { get; set; }
        public ChequeraBE oChequeraBE { get; set; }
        public MonedaBE oMonedaBE { get; set; }
        public CompaniaBE oCompaniaBE { get; set; }
    }
}

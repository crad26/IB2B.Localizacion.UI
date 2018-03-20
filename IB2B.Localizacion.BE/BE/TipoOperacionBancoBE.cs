using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class TipoOperacionBancoBE
    {
        public OperacionBancoBE ObOperacion { get; set; }
        public TipoPago_CobroBE ObPago_Cobro { get; set; }
        public int tipo { get; set; }
    }
}

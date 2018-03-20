using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class MonedaBE
    {
        public String MonedaId { get; set; }
        public String MonedaNomnbre { get; set; }
        public Decimal TipoCambio { get; set; }
        public String TasaCambioId { get; set; }
    }
}

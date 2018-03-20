using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class PagoDetraccionBE
    {
        public ChequeraBE OChequera { get; set; }
        [Display(Name = "Fecha de Transaccion ")]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }
        public TipoOperacionBE OTipoOperacion { get; set; }
        public TipoPagoBE OTipoPago { get; set; }
        public int NumeroOperacion { get; set; }
        public int NumeroArchivo { get; set; }
        public int RegistroImpuesto { get; set; }
        public int MontoTotalArchivo { get; set; }
        public int MontoTotalTransaccion { get; set; }
        public int NumeroLote { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime HoraPago { get; set; }
        public int NumeroDepositos { get; set; }
        public int estado { get; set; }

        //

        public string Constancia { get; set; }
        public int NumeroComprobante { get; set; }
        public int NumeroPago { get; set; }
        public ProveedorBE OProveedor { get; set; }
        public CategoriaBE OCategoria { get; set; }
        public int operacionID { get; set; }
        public decimal MontoDet { get; set; }
        public string periodo { get; set; }


    }
}

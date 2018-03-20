using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoOperacionBancoBL
    {
        #region Singleton

        private static TipoOperacionBancoBL vInstancia = null;
        private TipoOperacionBancoBL()
        {
        }
        public static TipoOperacionBancoBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoOperacionBancoBL(); return vInstancia; }
        }
        #endregion

        public List<TipoOperacionBancoBE> TipoOperacion_Sel(ComunBE pComunBE)
        {
            List<TipoOperacionBancoBE> vLItemBE = new List<TipoOperacionBancoBE>();
            TipoOperacionBancoBE obItemBE = new TipoOperacionBancoBE();
            OperacionBancoBE obOperacionBanco = new OperacionBancoBE();
            obOperacionBanco.IdOperacionBanco = 1;
            obOperacionBanco.DescripcionBanco = "DESCRIPCION";
            TipoPago_CobroBE obTipoPago_Cobro = new TipoPago_CobroBE();
            obTipoPago_Cobro.Id = 1;
            obTipoPago_Cobro.Descripcion = "DESCRIPCION TIPO PAGO COBRO";
            vLItemBE.Add(obItemBE);
            return vLItemBE;
        }
    }
}

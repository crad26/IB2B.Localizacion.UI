using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class PagoDetraccionBL
    {
        #region Singleton


        private static PagoDetraccionBL vInstancia = null;

        public PagoDetraccionBL()
        {

        }
        public static PagoDetraccionBL Instancia
        {
            get {
                if (vInstancia == null) vInstancia = new PagoDetraccionBL();
                   return vInstancia;
                }
        }
        #endregion
        public List<PagoDetraccionBE> ArticuloCriterio_Sel(ComunBE pComunBE)
        {
            List<PagoDetraccionBE> vLItemBE = new List<PagoDetraccionBE>();
            PagoDetraccionBE obItemBE = new PagoDetraccionBE();

            TipoOperacionBE obTipoOpBE = new TipoOperacionBE();
            TipoPagoBE obTipoPagoBE = new TipoPagoBE();
            ProveedorBE obProveBE = new ProveedorBE();
            CategoriaBE obCategBE = new CategoriaBE();
            
            obTipoPagoBE.TipoPagoNombre = "TPAGO1";
            obTipoOpBE.TipoOperacionNombre = "TOPERACION1";
            obProveBE.FRSTNAME = "NOMBRE";
            obCategBE.TB_CATEGORIA_DESC = "CATEGORIA1";

            obItemBE.OTipoOperacion = obTipoOpBE;
            obItemBE.OTipoPago = obTipoPagoBE;
            obItemBE.Constancia = "CONSTANCIA1";
            obItemBE.NumeroComprobante = 2000;
            obItemBE.NumeroPago = 1000;
            obItemBE.OProveedor =obProveBE;
            obItemBE.OCategoria = obCategBE;
            obItemBE.operacionID = 10;
            obItemBE.MontoDet = 100;
            obItemBE.periodo = "PERIODO";
            vLItemBE.Add(obItemBE);
            
            return vLItemBE;
        }


        public PagoDetraccionBE PagoDetraccionId_Sel(ComunBE pComunBE)
        {
            PagoDetraccionBE obItemBE = new PagoDetraccionBE();
            return obItemBE;
        }

        public Int32 PagoDetraccion_Ins(PagoDetraccionBE pItemBE)
        {
            return 1;
        }
    }
}
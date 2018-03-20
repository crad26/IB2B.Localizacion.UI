using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL
{
    public class TipoMovimientoBL
    {
        #region Singleton

        private static TipoMovimientoBL vInstancia = null;
        private TipoMovimientoBL()
        {
        }
        public static TipoMovimientoBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoMovimientoBL(); return vInstancia; }
        }
        #endregion

        public List<TipoMovimientoBE> TipoMovimiento_Sel(ComunBE pComunBE)
        {
            List<TipoMovimientoBE> vLItemBE = new List<TipoMovimientoBE>();
            TipoMovimientoBE obItemBE = new TipoMovimientoBE();
            CuentaBE obCuentaBE = new CuentaBE();
            obCuentaBE.NumeroCuenta = 099999;
            obCuentaBE.Descripcion = "TRASPASO DE SALDOS";
            TipoOperacionBE obTipoOperacion = new TipoOperacionBE();
            obTipoOperacion.TipoOperacionId = "04";
            obTipoOperacion.TipoOperacionNombre = "CONSIGNACION DE ENTREGA";
            TipoDocumentoBE obTipoDocumentoBE = new TipoDocumentoBE();
            obTipoDocumentoBE.TipoDocumentoID = "1";
            obTipoDocumentoBE.TipoDocumentoNombre = " GUIA DE REMISION";

            obItemBE.IDTipoMovimiento = 0001;
            obItemBE.Descripcion = "DESCRIPCION";
            obItemBE.OCuenta = obCuentaBE;
            obItemBE.tipo = "TIPO";
            obItemBE.oTipoOperacion = obTipoOperacion;
            obItemBE.MotivoTraslado = "IMPORTACIÓN";
            obItemBE.oTipoDocumento = obTipoDocumentoBE;
            obItemBE.IDSitioPredeterminado = 9999;
            
            vLItemBE.Add(obItemBE);
            return vLItemBE;
        }

    }
}

using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class ProveedorBL
    {
        #region Singleton

        private static ProveedorBL vInstancia = null;
        private ProveedorBL()
        {
        }
        public static ProveedorBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new ProveedorBL(); return vInstancia; }
        }
        #endregion

        public List<ProveedorBE> ProveedorCriterio_Sel(ComunBE pComunBE)
        {
            return ProveedorDAC.Instancia.ProveedorCriterio_Sel(pComunBE);
        }

        public ProveedorBE ProveedorId_Sel(ComunBE pComunBE)
        {
            return ProveedorDAC.Instancia.ProveedorId_Sel(pComunBE);
        }

        public Int32 Proveedor_Ins(ProveedorBE pProveedorBE)
        {
            return ProveedorDAC.Instancia.Proveedor_Ins(pProveedorBE);
        }
    }
}

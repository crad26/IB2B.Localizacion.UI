using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoRentaBL
    {
        #region Singleton

        private static TipoRentaBL vInstancia = null;
        private TipoRentaBL()
        {
        }
        public static TipoRentaBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoRentaBL(); return vInstancia; }
        }
        #endregion

        public List<TipoRentaBE> TipoRenta_Sel()
        {
            return TipoRentaDAC.Instancia.TipoRenta_Sel();
        }
    }
}

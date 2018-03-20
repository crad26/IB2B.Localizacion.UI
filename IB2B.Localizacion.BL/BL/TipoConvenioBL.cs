using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoConvenioBL
    {
        #region Singleton

        private static TipoConvenioBL vInstancia = null;
        private TipoConvenioBL()
        {
        }
        public static TipoConvenioBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoConvenioBL(); return vInstancia; }
        }
        #endregion

        public List<TipoConvenioBE> TipoConvenio_Sel()
        {
            return TipoConvenioDAC.Instancia.TipoConvenio_Sel();
        }
    }
}

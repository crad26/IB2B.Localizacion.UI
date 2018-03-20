using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoPersonaBL
    {
        #region Singleton

        private static TipoPersonaBL vInstancia = null;
        private TipoPersonaBL()
        {
        }
        public static TipoPersonaBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoPersonaBL(); return vInstancia; }
        }
        #endregion

        public List<TipoPersonaBE> TipoPersona_Sel()
        {
            return TipoPersonaDAC.Instancia.TipoPersona_Sel();
        }
    }
}

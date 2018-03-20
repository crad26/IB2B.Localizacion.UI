using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoBienesBL
    {
        #region Singleton

        private static TipoBienesBL vInstancia = null;
        private TipoBienesBL()
        {
        }
        public static TipoBienesBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoBienesBL(); return vInstancia; }
        }
        #endregion

        public List<TipoBienesBE> TipoBienes_Sel()
        {
            return TipoBienesDAC.Instancia.TipoBienes_Sel();
        }
    }
}

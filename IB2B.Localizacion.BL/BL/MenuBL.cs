using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class MenuBL
    {
        #region Singleton

        private static MenuBL vInstancia = null;
        private MenuBL()
        {
        }
        public static MenuBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new MenuBL(); return vInstancia; }
        }
        #endregion

        public List<MenuBE> Menu_Sel()
        {
            return MenuDAC.Instancia.Menu_Sel();
        }
    }
}

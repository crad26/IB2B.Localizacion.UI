using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class CategoriaBL
    {
        #region Singleton

        private static CategoriaBL vInstancia = null;
        private CategoriaBL()
        {
        }
        public static CategoriaBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new CategoriaBL(); return vInstancia; }
        }
        #endregion

        public List<CategoriaBE> Categoria_Sel()
        {
            return CategoriaDAC.Instancia.Categoria_Sel();
        }
    }
}

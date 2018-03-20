using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class SistemaBL
    {
        #region Singleton

        private static SistemaBL vInstancia = null;
        private SistemaBL()
        {
        }
        public static SistemaBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new SistemaBL(); return vInstancia; }
        }
        #endregion

        public UsuarioBE IngresoSistema(UsuarioBE pUsuarioBE)
        {
            UsuarioBE obUsuarioBE = SistemaDAC.Instancia.IngresoSistema(pUsuarioBE);
            if (String.IsNullOrEmpty(obUsuarioBE.Mensaje))
            {
                if (obUsuarioBE.Contrasenia_Usu != pUsuarioBE.Contrasenia_Usu)
                    obUsuarioBE = new UsuarioBE();
            }
            return obUsuarioBE;
        }
    }
}

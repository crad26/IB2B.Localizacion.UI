using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IB2B.Localizacion.BL.BL
{
    public class UsuarioBL
    {
        #region Singleton

        private static UsuarioBL vInstancia = null;
        private UsuarioBL()
        {
        }
        public static UsuarioBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new UsuarioBL(); return vInstancia; }
        }
        #endregion

        public Int32 RegistrarUsuario(UsuarioBE pUsuarioBE)
        {
            Int32 vResultado = 0;
            using (TransactionScope uTransaction = new TransactionScope(TransactionScopeOption.Required))
            {
                if (pUsuarioBE.Flag == Constantes.FlagRegistro.Actualizar)
                    vResultado = UsuarioDAC.Instancia.Usuario_Upd(pUsuarioBE);
                else
                    vResultado = UsuarioDAC.Instancia.Usuario_Ins(pUsuarioBE);
                if (vResultado > 0)
                    uTransaction.Complete();
            }
            return vResultado;
        }

        public String ValidarUsuario_Ins(String UsuarioId)
        {
            return UsuarioDAC.Instancia.ValidarUsuario_Ins(UsuarioId);
        }

        public List<UsuarioBE> UsuarioCriterio_Sel(String UsuarioId, String Nombre_Usu)
        {
            return UsuarioDAC.Instancia.UsuarioCriterio_Sel(UsuarioId, Nombre_Usu);
        }

        public Int32 Usuario_Del(String pUsuarioId)
        {
            return UsuarioDAC.Instancia.Usuario_Del(pUsuarioId);
        }

        public UsuarioBE UsuarioId_Sel(String pUsuarioId)
        {
            return UsuarioDAC.Instancia.UsuarioId_Sel(pUsuarioId);
        }
    }
}

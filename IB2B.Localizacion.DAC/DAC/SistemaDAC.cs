using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.DAC.DAC
{
    public class SistemaDAC
    {
        #region Singleton

        private static SistemaDAC vInstancia = null;
        private SistemaDAC()
        {
        }
        public static SistemaDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new SistemaDAC(); return vInstancia; }
        }
        #endregion

        public UsuarioBE IngresoSistema(UsuarioBE pUsuarioBE)
        {
            UsuarioBE obItemBE = new UsuarioBE();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_IngresoSistema_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.UsuarioId));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.Contrasenia_Usu));
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        obItemBE = getItem(sdr);
                }
                cnn.Close();
                cnn.Dispose();
            }
            return obItemBE;
        }

        public UsuarioBE getItem(SqlDataReader psdr)
        {
            UsuarioBE oUsuarioBE = new UsuarioBE();
            oUsuarioBE.UsuarioId = Convert.ToString(psdr["UsuarioId"]);
            oUsuarioBE.Usuario_Usu = Convert.ToString(psdr["Usuario_Usu"]);
            oUsuarioBE.Mensaje = Convert.ToString(psdr["Mensaje"]);
            return oUsuarioBE;
        }
    }
}

using ES.Solution.Util;
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
    public class UsuarioDAC
    {
        #region Singleton

        private static UsuarioDAC vInstancia = null;
        private UsuarioDAC()
        {
        }
        public static UsuarioDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new UsuarioDAC(); return vInstancia; }
        }
        #endregion

        public Int32 Usuario_Ins(UsuarioBE pUsuarioBE)
        {
            Int32 vResultado = 0;
            pUsuarioBE.Contrasenia_Usu = new EncryptDecryptEE().Encrypt(pUsuarioBE.Contrasenia_Usu);
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_Usuario_Ins", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.UsuarioId));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.Usuario_Usu));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.Contrasenia_Usu));
                    vResultado = command.ExecuteNonQuery();
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vResultado;
        }

        public String ValidarUsuario_Ins(String UsuarioId)
        {
            String nResultado = String.Empty;
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_ValidarUsuario_Ins", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => UsuarioId));
                    nResultado = Convert.ToString(command.ExecuteScalar());
                }
                cnn.Close();
                cnn.Dispose();
            }
            return nResultado;
        }

        public List<UsuarioBE> UsuarioCriterio_Sel(String UsuarioId, String Nombre_Usu)
        {
            List<UsuarioBE> vLUsuarioBE = new List<UsuarioBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_UsuarioCriterio_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => UsuarioId));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => Nombre_Usu));
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        vLUsuarioBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLUsuarioBE;
        }

        public UsuarioBE getItem(SqlDataReader psdr)
        {
            UsuarioBE oUsuarioBE = new UsuarioBE();
            oUsuarioBE.Activo_Usu = Convert.ToBoolean(psdr["Activo_Usu"]);
            oUsuarioBE.Contrasenia_Usu = new EncryptDecryptEE().Decrypt(Convert.ToString(psdr["Contrasenia_Usu"]));
            oUsuarioBE.RepetirContrasenia = oUsuarioBE.Contrasenia_Usu;
            oUsuarioBE.Usuario_Usu = Convert.ToString(psdr["Usuario_Usu"]);
            oUsuarioBE.UsuarioId = Convert.ToString(psdr["UsuarioId"]);
            return oUsuarioBE;
        }

        public Int32 Usuario_Upd(UsuarioBE pUsuarioBE)
        {
            pUsuarioBE.Contrasenia_Usu = new EncryptDecryptEE().Encrypt(pUsuarioBE.Contrasenia_Usu);
            Int32 vResultado = 0;
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_Usuario_Upd", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.UsuarioId));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.Usuario_Usu));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pUsuarioBE.Contrasenia_Usu));
                    vResultado = command.ExecuteNonQuery();
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vResultado;
        }

        public Int32 Usuario_Del(String UsuarioId)
        {
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_Usuario_Del", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => UsuarioId));
                    return command.ExecuteNonQuery();
                }
            }
        }

        public UsuarioBE UsuarioId_Sel(String UsuarioId)
        {
            UsuarioBE obUsuarioBE = new UsuarioBE();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_UsuarioId_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => UsuarioId));
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        obUsuarioBE = getItem(sdr);
                }
                cnn.Close();
                cnn.Dispose();
            }
            return obUsuarioBE;
        }
    }
}

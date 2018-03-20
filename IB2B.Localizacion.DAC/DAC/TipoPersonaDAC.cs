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
    public class TipoPersonaDAC
    {
        #region Singleton

        private static TipoPersonaDAC vInstancia = null;
        private TipoPersonaDAC()
        {
        }
        public static TipoPersonaDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoPersonaDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoPersonaBE> TipoPersona_Sel()
        {
            List<TipoPersonaBE> vLItemBE = new List<TipoPersonaBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoPersona_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        vLItemBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLItemBE;
        }

        public TipoPersonaBE getItem(SqlDataReader psdr)
        {
            TipoPersonaBE oItemBE = new TipoPersonaBE();
            oItemBE.TipoPersonaID = Convert.ToString(psdr["TipoPersonaID"]);
            oItemBE.TipoPersonaNombre = Convert.ToString(psdr["TipoPersonaNombre"]);
            return oItemBE;
        }
    }
}

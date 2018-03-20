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
    public class TipoOperacionBancoDAC
    {
        #region Singleton

        private static TipoOperacionBancoDAC vInstancia = null;
        private TipoOperacionBancoDAC()
        {
        }
        public static TipoOperacionBancoDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoOperacionBancoDAC(); return vInstancia; }
        }
        #endregion


        public List<TipoOperacionBancoBE    > ClienteCriterio_Sel(ComunBE pComunBE)
        {
            List<TipoOperacionBancoBE> vLItemBE = new List<TipoOperacionBancoBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ClienteCriterio_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio01));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio02));
                    SqlDataReader sdr = command.ExecuteReader();
                   // while (sdr.Read())
                        //vLItemBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLItemBE;
        }

    }
}

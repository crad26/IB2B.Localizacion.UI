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
    public class TipoConvenioDAC
    {
        #region Singleton

        private static TipoConvenioDAC vInstancia = null;
        private TipoConvenioDAC()
        {
        }
        public static TipoConvenioDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoConvenioDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoConvenioBE> TipoConvenio_Sel()
        {
            List<TipoConvenioBE> vLItemBE = new List<TipoConvenioBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoConvenio_Sel", cnn))
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

        public TipoConvenioBE getItem(SqlDataReader psdr)
        {
            TipoConvenioBE oItemBE = new TipoConvenioBE();
            oItemBE.ConvenioID = Convert.ToString(psdr["ConvenioID"]);
            oItemBE.ConvenioNombre = Convert.ToString(psdr["ConvenioNombre"]);
            return oItemBE;
        }
    }
}

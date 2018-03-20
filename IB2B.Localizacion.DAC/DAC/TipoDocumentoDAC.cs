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
    public class TipoDocumentoDAC
    {
        #region Singleton

        private static TipoDocumentoDAC vInstancia = null;
        private TipoDocumentoDAC()
        {
        }
        public static TipoDocumentoDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoDocumentoDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoDocumentoBE> TipoDocumento_Sel()
        {
            List<TipoDocumentoBE> vLItemBE = new List<TipoDocumentoBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoDocumento_Sel", cnn))
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

        public TipoDocumentoBE getItem(SqlDataReader psdr)
        {
            TipoDocumentoBE oItemBE = new TipoDocumentoBE();
            oItemBE.TipoDocumentoID = Convert.ToString(psdr["TipoDocumentoID"]);
            oItemBE.TipoDocumentoNombre = Convert.ToString(psdr["TipoDocumentoNombre"]);
            return oItemBE;
        }
    }
}

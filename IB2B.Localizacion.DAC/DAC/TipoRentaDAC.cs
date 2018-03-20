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
    public class TipoRentaDAC
    {
        #region Singleton

        private static TipoRentaDAC vInstancia = null;
        private TipoRentaDAC()
        {
        }
        public static TipoRentaDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoRentaDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoRentaBE> TipoRenta_Sel()
        {
            List<TipoRentaBE> vLItemBE = new List<TipoRentaBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoRenta_Sel", cnn))
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

        public TipoRentaBE getItem(SqlDataReader psdr)
        {
            TipoRentaBE oItemBE = new TipoRentaBE();
            oItemBE.RentaID = Convert.ToString(psdr["RentaID"]);
            oItemBE.RentaNombre = Convert.ToString(psdr["RentaNombre"]);
            return oItemBE;
        }
    }
}

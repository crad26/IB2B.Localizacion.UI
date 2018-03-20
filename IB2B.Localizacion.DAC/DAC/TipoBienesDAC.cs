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
    public class TipoBienesDAC
    {
        #region Singleton

        private static TipoBienesDAC vInstancia = null;
        private TipoBienesDAC()
        {
        }
        public static TipoBienesDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoBienesDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoBienesBE> TipoBienes_Sel()
        {
            List<TipoBienesBE> vLTipoBienesBE = new List<TipoBienesBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoBienes_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        vLTipoBienesBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLTipoBienesBE;
        }

        public TipoBienesBE getItem(SqlDataReader psdr)
        {
            TipoBienesBE oItemBE = new TipoBienesBE();
            oItemBE.BienesID = Convert.ToString(psdr["BienesID"]);
            oItemBE.BienesNombre = Convert.ToString(psdr["BienesNombre"]);
            return oItemBE;
        }
    }
}

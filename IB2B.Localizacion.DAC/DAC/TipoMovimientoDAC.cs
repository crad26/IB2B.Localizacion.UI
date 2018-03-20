using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.DAC.DAC
{
    public class TipoMovimientoDAC
    {
        #region Singleton

        private static TipoMovimientoDAC vInstancia = null;
        private TipoMovimientoDAC()
        {
        }
        public static TipoMovimientoDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoMovimientoDAC(); return vInstancia; }
        }
        #endregion

        public List<TipoMovimientoBE> TipoConvenio_Sel()
        {
            List<TipoMovimientoBE> vLItemBE = new List<TipoMovimientoBE>();
            //using (SqlConnection cnn = ConnectionManager.GetConnection())
            //{
            //    using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_TipoConvenio_Sel", cnn))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;
            //        SqlDataReader sdr = command.ExecuteReader();
            //        while (sdr.Read())
            //            vLItemBE.Add(getItem(sdr));
            //    }
            //    cnn.Close();
            //    cnn.Dispose();
            //}
            return vLItemBE;
        }
    }
}

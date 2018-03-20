using ES.DentalPeruERP.BE;
using ES.DentalPeruERP.BE.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Solution.Util;

namespace ES.DentalPeruERP.DAC
{
    public class EstadoCitaDAC
    {
        #region Singleton

        private static EstadoCitaDAC vInstancia = null;
        private EstadoCitaDAC()
        {
        }
        public static EstadoCitaDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new EstadoCitaDAC(); return vInstancia; }
        }
        #endregion

        public List<EstadoCitaBE> EstadoCita_Sel()
        {
            List<EstadoCitaBE> vLEstadoCitaBE = new List<EstadoCitaBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("Es_Sp_CitaEstado_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    vLEstadoCitaBE.LoadFromReader(dt);
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLEstadoCitaBE;
        }
    }
}

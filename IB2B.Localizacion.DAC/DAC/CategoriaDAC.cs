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
    public class CategoriaDAC
    {
        
        #region Singleton

        private static CategoriaDAC vInstancia = null;
        private CategoriaDAC()
        {
        }
        public static CategoriaDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new CategoriaDAC(); return vInstancia; }
        }
        #endregion

        public List<CategoriaBE> Categoria_Sel()
        {
            List<CategoriaBE> vLItemBE = new List<CategoriaBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_CategoriaArticulo_Sel", cnn))
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

        public CategoriaBE getItem(SqlDataReader psdr)
        {
            CategoriaBE oItemBE = new CategoriaBE();
            oItemBE.TB_CATEGORIA_ID = Convert.ToString(psdr["TB_CATEGORIA_ID"]);
            oItemBE.TB_CATEGORIA_DESC = Convert.ToString(psdr["TB_CATEGORIA_DESC"]);
            return oItemBE;
        }
    }
}

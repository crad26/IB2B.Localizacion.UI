using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.DAC.DAC
{
    public class MenuDAC
    {
        #region Singleton

        private static MenuDAC vInstancia = null;
        private MenuDAC()
        {
        }
        public static MenuDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new MenuDAC(); return vInstancia; }
        }
        #endregion

        public List<MenuBE> Menu_Sel()
        {
            List<MenuBE> vLMenuBE = new List<MenuBE>();
            //using (SqlConnection cnn = ConnectionManager.GetConnection())
            //{
            //    using (SqlCommand command = new SqlCommand("Es_Sp_Menu_Sel", cnn))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;
            //        SqlDataReader sdr = command.ExecuteReader();
            //        while (sdr.Read())
            //            vLMenuBE.Add(getItem(sdr));
            //    }
            //    cnn.Close();
            //    cnn.Dispose();
            //}
            return vLMenuBE;
        }

        public MenuBE getItem(SqlDataReader psdr)
        {
            MenuBE oEstadoBE = new MenuBE();
            oEstadoBE.MenuId = Convert.ToInt32(psdr["MenuId"]);
            oEstadoBE.Nombre_Mnu = Convert.ToString(psdr["Nombre_Men"]);
            oEstadoBE.Html_Mnu = string.Format(Convert.ToString(psdr["Html_Men"]), Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"])).Trim();
            oEstadoBE.Orden_Mnu = Convert.ToInt32(psdr["Orden_Men"]);
            oEstadoBE.Padre_Mnu = Convert.ToInt32(psdr["Padre_Men"]);
            oEstadoBE.Visible_Mnu = Convert.ToInt32(psdr["Visible_Men"]);
            return oEstadoBE;
        }
    }
}

using ES.Solution.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.DAC.DAC
{
    public class ConnectionManager :  SenderDAC
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                //String vDataSource = @"WIN2012GP2015\SQLSERVER2014";
                //String vCatalog = "DBLocalizacion";
                //String vUser = "sa";
                //String vPassword = "srvGP2015sa";

                String vDataSource = "(local)";
                String vCatalog = "DBLocalizacion";
                String CadenaConexion = String.Format("Data Source=.;Initial Catalog=DBLocalizacion;Integrated Security=True");
                SqlConnection connection = new SqlConnection(CadenaConexion);
                connection.Open();
                return connection;
            }
            catch (Exception exx)
            {
                return null;
            }
        }
    }
}

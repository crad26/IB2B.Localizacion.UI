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
    public class ClienteDAC
    {
        #region Singleton

        private static ClienteDAC vInstancia = null;
        private ClienteDAC()
        {
        }
        public static ClienteDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new ClienteDAC(); return vInstancia; }
        }
        #endregion

        public List<ClienteBE> ClienteCriterio_Sel(ComunBE pComunBE)
        {
            List<ClienteBE> vLItemBE = new List<ClienteBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ClienteCriterio_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio01));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio02));
                    SqlDataReader sdr = command.ExecuteReader();
                    //while (sdr.Read())
                    //    vLItemBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLItemBE;
        }



        public ClienteBE ClienteId_Sel(ComunBE pComunBE)
        {
            ClienteBE obItemBE = new ClienteBE();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ClienteId_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.DocumentoId));
                    SqlDataReader sdr = command.ExecuteReader();
                    //if (sdr.Read())
                    //    obItemBE = getItemId(sdr);
                }
                cnn.Close();
                cnn.Dispose();
            }
            return obItemBE;
        }

        //public ClienteBE getItemId(SqlDataReader psdr)
        //{
        //    ClienteBE oItemBE = new ClienteBE();
        //    oItemBE.CUSTNMBR = Convert.ToString(psdr["CUSTNMBR"]);
        //    oItemBE.CUSTNAME = Convert.ToString(psdr["CUSTNAME"]);
        //    oItemBE.oTipoPersonaBE.TipoPersonaID = Convert.ToString(psdr["TipoPersonaID"]);
        //    oItemBE.oTipoDocumentoBE.TipoDocumentoID = Convert.ToString(psdr["TipoDocumentoID"]);
        //    oItemBE.TB_NRO_DOCUMENTO = Convert.ToString(psdr["TB_NRO_DOCUMENTO"]);
        //    oItemBE.TB_REFERENCIA = Convert.ToString(psdr["TB_REFERENCIA"]);
        //    oItemBE.TB_RAZON_SOCIAL = Convert.ToString(psdr["TB_RAZON_SOCIAL"]);
        //    oItemBE.FRSTNAME = Convert.ToString(psdr["FRSTNAME"]);
        //    oItemBE.SHRTNAME = Convert.ToString(psdr["SHRTNAME"]);
        //    oItemBE.LASTNAME = Convert.ToString(psdr["LASTNAME"]);
        //    oItemBE.MIDLNAME = Convert.ToString(psdr["MIDLNAME"]);
        //    oItemBE.CB_BC = Convert.ToBoolean(psdr["CB_BC"]);
        //    if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_BC_FECHA1"])))
        //        oItemBE.DT_BC_FECHA1 = Convert.ToDateTime(psdr["DT_BC_FECHA1"]);
        //    oItemBE.CB_AR = Convert.ToBoolean(psdr["CB_AR"]);
        //    if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_AR_FECHA1"])))
        //        oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_AR_FECHA1"]);
        //    oItemBE.CB_AP = Convert.ToBoolean(psdr["CB_AP"]);
        //    if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_AP_FECHA1"])))
        //        oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_AP_FECHA1"]);
        //    oItemBE.CB_RI = Convert.ToBoolean(psdr["CB_RI"]);
        //    if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_RI_FECHA1"])))
        //        oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_RI_FECHA1"]);
        //    oItemBE.CB_NH = Convert.ToBoolean(psdr["CB_NH"]);
        //    if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_NH_FECHA1"])))
        //        oItemBE.DT_NH_FECHA1 = Convert.ToDateTime(psdr["DT_NH_FECHA1"]);
        //    return oItemBE;
        //}

        public Int32 Cliente_Ins(ClienteBE pClienteBE)
        {
            Int32 nResult = 0;
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_Cliente_Ins", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CUSTNMBR));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CUSTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.oTipoPersonaBE.TipoPersonaID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.oTipoDocumentoBE.TipoDocumentoID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.TB_NRO_DOCUMENTO));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.TB_REFERENCIA));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.TB_RAZON_SOCIAL));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.FRSTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.SHRTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.LASTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.MIDLNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CB_BC));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.DT_BC_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CB_AR));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.DT_AR_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CB_AP));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.DT_AP_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CB_RI));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.DT_RI_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.CB_NH));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pClienteBE.DT_NH_FECHA1));
                    nResult = Convert.ToInt32(command.ExecuteNonQuery());
                }
                cnn.Close();
                cnn.Dispose();
            }
            return nResult;
        }
    }
}

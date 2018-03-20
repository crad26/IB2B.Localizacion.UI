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
    public class ProveedorDAC
    {
        #region Singleton

        private static ProveedorDAC vInstancia = null;
        private ProveedorDAC()
        {
        }
        public static ProveedorDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new ProveedorDAC(); return vInstancia; }
        }
        #endregion

        public List<ProveedorBE> ProveedorCriterio_Sel(ComunBE pComunBE)
        {
            List<ProveedorBE> vLItemBE = new List<ProveedorBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ProveedorCriterio_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio01));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.Criterio02));
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                        vLItemBE.Add(getItem(sdr));
                }
                cnn.Close();
                cnn.Dispose();
            }
            return vLItemBE;
        }

        public ProveedorBE getItem(SqlDataReader psdr)
        {
            ProveedorBE oItemBE = new ProveedorBE();
            oItemBE.VENDORID = Convert.ToString(psdr["VENDORID"]);
            oItemBE.VENDNAME = Convert.ToString(psdr["VENDNAME"]);
            oItemBE.oTipoPersonaBE.TipoPersonaNombre = Convert.ToString(psdr["TipoPersonaNombre"]);
            oItemBE.oTipoDocumentoBE.TipoDocumentoNombre = Convert.ToString(psdr["TipoDocumentoNombre"]);
            oItemBE.TB_NRO_DOCUMENTO = Convert.ToString(psdr["TB_NRO_DOCUMENTO"]);
            oItemBE.TB_RAZON_SOCIAL = Convert.ToString(psdr["TB_RAZON_SOCIAL"]);
            return oItemBE;
        }

        public ProveedorBE ProveedorId_Sel(ComunBE pComunBE)
        {
            ProveedorBE obItemBE = new ProveedorBE();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ProveedorId_Sel", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pComunBE.DocumentoId));
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                        obItemBE = getItemId(sdr);
                }
                cnn.Close();
                cnn.Dispose();
            }
            return obItemBE;
        }

        public ProveedorBE getItemId(SqlDataReader psdr)
        {
            ProveedorBE oItemBE = new ProveedorBE();
            oItemBE.VENDORID = Convert.ToString(psdr["VENDORID"]);
            oItemBE.VENDNAME = Convert.ToString(psdr["VENDNAME"]);
            oItemBE.oTipoPersonaBE.TipoPersonaID = Convert.ToString(psdr["TipoPersonaID"]);
            oItemBE.oTipoDocumentoBE.TipoDocumentoID = Convert.ToString(psdr["TipoDocumentoID"]);
            oItemBE.TB_NRO_DOCUMENTO = Convert.ToString(psdr["TB_NRO_DOCUMENTO"]);            
            oItemBE.TB_REFERENCIA = Convert.ToString(psdr["TB_REFERENCIA"]);
            oItemBE.TB_RAZON_SOCIAL = Convert.ToString(psdr["TB_RAZON_SOCIAL"]);
            oItemBE.FRSTNAME = Convert.ToString(psdr["FRSTNAME"]);
            oItemBE.SHRTNAME = Convert.ToString(psdr["SHRTNAME"]);
            oItemBE.LASTNAME = Convert.ToString(psdr["LASTNAME"]);
            oItemBE.MIDLNAME = Convert.ToString(psdr["MIDLNAME"]);
            oItemBE.CB_BC = Convert.ToBoolean(psdr["CB_BC"]);
            if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_BC_FECHA1"])))
                oItemBE.DT_BC_FECHA1 = Convert.ToDateTime(psdr["DT_BC_FECHA1"]);
            oItemBE.CB_AR = Convert.ToBoolean(psdr["CB_AR"]);
            if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_AR_FECHA1"])))
                oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_AR_FECHA1"]);
            oItemBE.CB_AP = Convert.ToBoolean(psdr["CB_AP"]);
            if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_AP_FECHA1"])))
                oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_AP_FECHA1"]);
            oItemBE.CB_RI = Convert.ToBoolean(psdr["CB_RI"]);
            if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_RI_FECHA1"])))
                oItemBE.DT_AR_FECHA1 = Convert.ToDateTime(psdr["DT_RI_FECHA1"]);
            oItemBE.CB_NH = Convert.ToBoolean(psdr["CB_NH"]);
            if (!String.IsNullOrEmpty(Convert.ToString(psdr["DT_NH_FECHA1"])))
                oItemBE.DT_NH_FECHA1 = Convert.ToDateTime(psdr["DT_NH_FECHA1"]);
            oItemBE.oTipoConvenioBE.ConvenioID = Convert.ToString(psdr["ConvenioID"]);
            oItemBE.oTipoRentaBE.RentaID = Convert.ToString(psdr["RentaID"]);
            oItemBE.CB_EA = Convert.ToBoolean(psdr["CB_EA"]);
            return oItemBE;
        }

        public Int32 Proveedor_Ins(ProveedorBE pProveedorBE)
        {
            Int32 nResult = 0;
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_Proveedor_Ins", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.VENDORID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.VENDNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.oTipoPersonaBE.TipoPersonaID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.oTipoDocumentoBE.TipoDocumentoID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.TB_NRO_DOCUMENTO));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.TB_REFERENCIA));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.TB_RAZON_SOCIAL));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.FRSTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.SHRTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.LASTNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.MIDLNAME));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.CB_BC));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.DT_BC_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.CB_AR));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.DT_AR_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.CB_AP));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.DT_AP_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.CB_RI));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.DT_RI_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.CB_NH));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.DT_NH_FECHA1));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.oTipoConvenioBE.ConvenioID));
                    command.Parameters.Add(ConnectionManager.GetParametro(() => pProveedorBE.oTipoRentaBE.RentaID));
                    nResult = Convert.ToInt32(command.ExecuteNonQuery());
                }
                cnn.Close();
                cnn.Dispose();
            }
            return nResult;
        }
    }
}

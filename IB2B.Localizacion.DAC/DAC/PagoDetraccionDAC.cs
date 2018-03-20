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
   public class PagoDetraccionDAC
    {
        #region Singleton

        private static PagoDetraccionDAC vInstancia = null;
        private PagoDetraccionDAC()
        {
        }
        public static PagoDetraccionDAC Instancia
        {
            get { if (vInstancia == null) vInstancia = new PagoDetraccionDAC(); return vInstancia; }
        }
        #endregion

        public PagoDetraccionBE getItem(SqlDataReader psdr)
        {
            PagoDetraccionBE oItemBE = new PagoDetraccionBE();
            oItemBE.Constancia = Convert.ToString(psdr["CUSTNMBR"]);
            oItemBE.NumeroComprobante = Convert.ToInt32(psdr["CUSTNAME"]);
            oItemBE.NumeroPago = Convert.ToInt32(psdr["CUSTNAME"]);
            oItemBE.OProveedor.LASTNAME = Convert.ToString(psdr["CUSTNAME"]);
            oItemBE.OCategoria.TB_CATEGORIA_ID = Convert.ToString(psdr["CUSTNAME"]);
            oItemBE.OTipoOperacion.TipoOperacionId = Convert.ToString(psdr["CUSTNAME"]);
            oItemBE.MontoDet = Convert.ToDecimal(psdr["CUSTNAME"]);
            return oItemBE;
        }

        public List<PagoDetraccionBE> PagoDetraccionCriterio_Sel(ComunBE pComunBE)
        {
            List<PagoDetraccionBE> vLItemBE = new List<PagoDetraccionBE>();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ClienteCriterio_Sel", cnn))
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

        public PagoDetraccionBE PagoDetraccionId_Sel(ComunBE pComunBE)
        {
            PagoDetraccionBE obItemBE = new PagoDetraccionBE();
            using (SqlConnection cnn = ConnectionManager.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_ClienteId_Sel", cnn))
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

        public PagoDetraccionBE getItemId(SqlDataReader psdr)
        {
            PagoDetraccionBE oItemBE = new PagoDetraccionBE();
        
            return oItemBE;
        }


        //public Int32 PagoDetraccion_Ins(PagoDetraccionBE pPagoDetraccionBE)
        //{
        //    Int32 nResult = 0;
        //    using (SqlConnection cnn = ConnectionManager.GetConnection())
        //    {
        //        using (SqlCommand command = new SqlCommand("IB2B_SP_LOC_Cliente_Ins", cnn))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CUSTNAME));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.oTipoPersonaBE.TipoPersonaID));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.oTipoDocumentoBE.TipoDocumentoID));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.TB_NRO_DOCUMENTO));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.TB_REFERENCIA));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.TB_RAZON_SOCIAL));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.FRSTNAME));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.SHRTNAME));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.LASTNAME));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.MIDLNAME));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CB_BC));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.DT_BC_FECHA1));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CB_AR));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.DT_AR_FECHA1));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CB_AP));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.DT_AP_FECHA1));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CB_RI));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.DT_RI_FECHA1));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.CB_NH));
        //            command.Parameters.Add(ConnectionManager.GetParametro(() => pPagoDetraccionBE.DT_NH_FECHA1));
        //            nResult = Convert.ToInt32(command.ExecuteNonQuery());
        //        }
        //        cnn.Close();
        //        cnn.Dispose();
        //    }
        //    return nResult;
        //}
    }
}

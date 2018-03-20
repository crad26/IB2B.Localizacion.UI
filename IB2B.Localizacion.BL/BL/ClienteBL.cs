using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class ClienteBL
    {
        #region Singleton

        private static ClienteBL vInstancia = null;
        private ClienteBL()
        {
        }
        public static ClienteBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new ClienteBL(); return vInstancia; }
        }
        #endregion

        //public List<ClienteBE> ClienteCriterio_Sel(ComunBE pComunBE)
        //{
        //    return ClienteDAC.Instancia.ClienteCriterio_Sel(pComunBE);
        //}


        public List<ClienteBE> ClienteCriterio_Sel(ComunBE pComunBE)
        {
            List<ClienteBE> vLItemBE = new List<ClienteBE>();
            ClienteBE obItemBE = new ClienteBE();
            obItemBE.oTipoPersonaBE.TipoPersonaNombre = "PERSONA1";
            obItemBE.oTipoDocumentoBE.TipoDocumentoNombre = "DOCUMENTO1";
            obItemBE.FRSTNAME = "FIRSNAME";
            obItemBE.LASTNAME = "LASTNAME";
            obItemBE.TB_NRO_DOCUMENTO = "NUMERODOC";
            obItemBE.TB_REFERENCIA = "REFERENCIA";
            obItemBE.TB_RAZON_SOCIAL = "RAZON SOCIAL";
            vLItemBE.Add(obItemBE);
            return vLItemBE;
        }

        public ClienteBE ClienteId_Sel(ComunBE pComunBE)
        {
            return ClienteDAC.Instancia.ClienteId_Sel(pComunBE);
        }
        public Int32 Cliente_Ins(ClienteBE pClienteBE)
        {
            return ClienteDAC.Instancia.Cliente_Ins(pClienteBE);
        }
    }
}

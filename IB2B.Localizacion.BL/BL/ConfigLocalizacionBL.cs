using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class ConfigLocalizacionBL
    {
        #region Singleton

        private static ConfigLocalizacionBL vInstancia = null;
        private ConfigLocalizacionBL()
        {
        }
        public static ConfigLocalizacionBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new ConfigLocalizacionBL(); return vInstancia; }
        }

        #endregion

        public List<ConfigLocalizacionBE> ListaTipoDocumento(ComunBE pComunBE)
        {
            List<ConfigLocalizacionBE> vLItemBE = new List<ConfigLocalizacionBE>();
            ConfigLocalizacionBE obItemBE = new ConfigLocalizacionBE();
            TipoDocumentoBE obTipoDocumento = new TipoDocumentoBE();
            obTipoDocumento.TipoDocumentoID = "00";
            obTipoDocumento.TipoDocumentoNombre = "OTROS";
            //
            //
            obItemBE.oTipoDocumento = obTipoDocumento;

            vLItemBE.Add(obItemBE);
            obItemBE = new ConfigLocalizacionBE();
            return vLItemBE;
        }

    }
}

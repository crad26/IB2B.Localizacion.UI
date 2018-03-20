using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.DAC.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class TipoDocumentoBL
    {
        #region Singleton

        private static TipoDocumentoBL vInstancia = null;
        private TipoDocumentoBL()
        {
        }
        public static TipoDocumentoBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new TipoDocumentoBL(); return vInstancia; }
        }
        #endregion

        public List<TipoDocumentoBE> TipoDocumento_Sel()
        {
            return TipoDocumentoDAC.Instancia.TipoDocumento_Sel();
        }
    }
}

using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class ConfigLocalizacionModel
    {
        public ConfigLocalizacionModel()
        {
            this.oComunBE = new ComunBE();
            this.oTipoDocumento = new TipoDocumentoBE();
            this.ObConfigLocalizacionBE = new ConfigLocalizacionBE();

        }
        public ComunBE oComunBE { get; set; }
        public ConfigLocalizacionBE ObConfigLocalizacionBE { get; set; }
        public TipoDocumentoBE oTipoDocumento { get; set; }
    }
}
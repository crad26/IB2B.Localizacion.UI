using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Models
{
    public class ClienteModels
    {
        public ClienteModels()
        {
            this.oComunBE = new ComunBE();
            this.oClienteBE = new ClienteBE();
            this.vLTipoPersonaBE = new List<TipoPersonaBE>();
            this.vLTipoDocumentoBE = new List<TipoDocumentoBE>();
        }
        public ComunBE oComunBE { get; set; }
        public ClienteBE oClienteBE { get; set; }
        public List<TipoPersonaBE> vLTipoPersonaBE { get; set; }
        public List<TipoDocumentoBE> vLTipoDocumentoBE { get; set; }
    }
}
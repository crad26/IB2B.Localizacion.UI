using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class ArticuloBL
    {
        #region Singleton

        private static ArticuloBL vInstancia = null;
        private ArticuloBL()
        {
        }
        public static ArticuloBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new ArticuloBL(); return vInstancia; }
        }
        #endregion

        public List<ArticuloBE> ArticuloCriterio_Sel(ComunBE pComunBE)
        {
            List<ArticuloBE> vLItemBE = new List<ArticuloBE>();
            ArticuloBE obItemBE = new ArticuloBE();
            obItemBE.ITEMNMBR = "ART0001";
            obItemBE.ITEMDESC = "Articulo";
            obItemBE.UOMSCHDL = "UND";
            obItemBE.ITMTRKOP = "co";
            vLItemBE.Add(obItemBE);
            obItemBE = new ArticuloBE();
            obItemBE.ITEMNMBR = "ART0002";
            obItemBE.ITEMDESC = "Articulo2";
            obItemBE.UOMSCHDL = "UND";
            obItemBE.ITMTRKOP = "co";
            vLItemBE.Add(obItemBE);
            obItemBE = new ArticuloBE();
            obItemBE.ITEMNMBR = "ART0003";
            obItemBE.ITEMDESC = "Articulo3";
            obItemBE.UOMSCHDL = "UND";
            obItemBE.ITMTRKOP = "co";
            vLItemBE.Add(obItemBE);
            return vLItemBE;
        }

        public ArticuloBE ArticuloId_Sel(ComunBE pComunBE)
        {
            ArticuloBE obItemBE = new ArticuloBE();
            return obItemBE;
        }

        public Int32 Articulo_Ins(ArticuloBE pItemBE)
        {
            return 1;
        }
    }
}

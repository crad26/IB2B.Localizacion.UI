using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BL.BL
{
    public class ArticuloControladoBL
    {
        #region Singleton

        private static ArticuloControladoBL vInstancia = null;
        private ArticuloControladoBL()
        {
        }
        public static ArticuloControladoBL Instancia
        {
            get { if (vInstancia == null) vInstancia = new ArticuloControladoBL(); return vInstancia; }
        }
        #endregion

        public List<ArticuloControladoBE> ArticuloControlado_Sel()
        {
            List<ArticuloControladoBE> vLItemBE = new List<ArticuloControladoBE>();
            ArticuloControladoBE obItemBE = new ArticuloControladoBE();
            obItemBE.TB_CONTROLADO_ID = "CONT01";
            obItemBE.TB_CONTROLADO_DESC = "DESCO1";
            vLItemBE.Add(obItemBE);
            obItemBE = new ArticuloControladoBE();
            obItemBE.TB_CONTROLADO_ID = "CONT02";
            obItemBE.TB_CONTROLADO_DESC = "DESCO2";
            vLItemBE.Add(obItemBE);
            obItemBE = new ArticuloControladoBE();
            obItemBE.TB_CONTROLADO_ID = "CONT03";
            obItemBE.TB_CONTROLADO_DESC = "DESCO3";
            vLItemBE.Add(obItemBE);
            return vLItemBE;
        }
    }
}

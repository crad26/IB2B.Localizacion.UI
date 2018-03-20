using IB2B.Localizacion.UI.Models;
using IB2B.Localizacion.UI.Helpers;
using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.BL.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IB2B.Localizacion.UI.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        [OutputCache(Duration = 0)]
        public ActionResult Listar()
        {
            ArticuloModels oModel = new ArticuloModels();
            return View(oModel);
        }
        
        [OutputCache(Duration = 0)]
        public ActionResult ListaArticuloCriterio(String pArticuloId, String pDescripcion)
        {
            try
            {
                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pArticuloId;
                oItemBE.Criterio02 = pDescripcion;
                List<ArticuloBE> vLItemBE = ArticuloBL.Instancia.ArticuloCriterio_Sel(oItemBE);
                foreach (ArticuloBE o in vLItemBE)
                {
                    o.Url_Detalle = HtmlExtensionHelpers.UrlEncodedActionLink(null, "Registrar", Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"]) + "Articulo", new { pArticuloId = o.ITEMNMBR }).ToString();
                }
                var jsonResult = Json(vLItemBE, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = Int32.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
            }
        }

        [OutputCache(Duration = 0)]
        public ActionResult Registrar(String pArticuloId)
        {
            ArticuloModels oModel = new ArticuloModels();
            oModel.vLArticuloControladoBE = ArticuloControladoBL.Instancia.ArticuloControlado_Sel();
            oModel.vLCategoriaBE = CategoriaBL.Instancia.Categoria_Sel();
            oModel.oComunBE.Flag = Constantes.FlagRegistro.Insertar;
            if (!String.IsNullOrEmpty(pArticuloId))
            {
                ComunBE obComunBE = new ComunBE();
                obComunBE.DocumentoId = pArticuloId;
                oModel.oArticuloBE = ArticuloBL.Instancia.ArticuloId_Sel(obComunBE);
                if (!String.IsNullOrEmpty(oModel.oArticuloBE.ITEMNMBR))
                    oModel.oComunBE.Flag = Constantes.FlagRegistro.Actualizar;
            }
            return View(oModel);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult Registrar(ArticuloModels pItem)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                if (ArticuloBL.Instancia.Articulo_Ins(pItem.oArticuloBE) > 0)
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                else
                {
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                }
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }
    }
}
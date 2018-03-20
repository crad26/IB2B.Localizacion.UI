using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.BL.BL;
using IB2B.Localizacion.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI.Controllers
{
    public class PagoDetraccionController : Controller
    {
        [OutputCache(Duration = 0)]
        public ActionResult Listar()
        {
            PagoDetraccionModel oModel = new PagoDetraccionModel();
            return View(oModel);
        }


        [OutputCache(Duration = 0)]
        public ActionResult ListaPagoDetraccionCriterio(String pRUC, String pRazonSocial)
        {
            try
            {
                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pRUC;
                oItemBE.Criterio02 = pRazonSocial;
                List<PagoDetraccionBE> vLItemBE = PagoDetraccionBL.Instancia.ArticuloCriterio_Sel(oItemBE);
                foreach (PagoDetraccionBE o in vLItemBE)
                {
                   // o.Url_Detalle = HtmlExtensionHelpers.UrlEncodedActionLink(null, "Registrar", Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"]) + "Cliente", new { pClienteId = o.CUSTNMBR }).ToString();
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
    }
}
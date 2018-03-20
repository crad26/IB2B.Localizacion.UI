using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.BL.BL;
using IB2B.Localizacion.UI.Helpers;
using IB2B.Localizacion.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        [OutputCache(Duration = 0)]
        public ActionResult Listar()
        {
            ProveedorModels oModel = new ProveedorModels();
            return View(oModel);
        }

        [OutputCache(Duration = 0)]
        public ActionResult ListaProveedorCriterio(String pRUC, String pRazonSocial)
        {
            try
            {
                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pRUC;
                oItemBE.Criterio02 = pRazonSocial;
                List<ProveedorBE> vLItemBE = ProveedorBL.Instancia.ProveedorCriterio_Sel(oItemBE);
                foreach (ProveedorBE o in vLItemBE)
                {
                    o.Url_Detalle = HtmlExtensionHelpers.UrlEncodedActionLink(null, "Registrar", Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"]) + "Proveedor", new { pProveedorId = o.VENDORID}).ToString();
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
        public ActionResult Registrar(String pProveedorId)
        {
            ProveedorModels oModel = new ProveedorModels();
            oModel.vLTipoConvenioBE = TipoConvenioBL.Instancia.TipoConvenio_Sel();
            oModel.vLTipoDocumentoBE = TipoDocumentoBL.Instancia.TipoDocumento_Sel();
            oModel.vLTipoPersonaBE = TipoPersonaBL.Instancia.TipoPersona_Sel();
            oModel.vLTipoRentaBE = TipoRentaBL.Instancia.TipoRenta_Sel();
            oModel.vLTipoBienesBE = TipoBienesBL.Instancia.TipoBienes_Sel();
            oModel.oComunBE.Flag = Constantes.FlagRegistro.Insertar;
            if (!String.IsNullOrEmpty(pProveedorId))
            {
                ComunBE obComunBE = new ComunBE();
                obComunBE.DocumentoId = pProveedorId;
                oModel.oProveedorBE = ProveedorBL.Instancia.ProveedorId_Sel(obComunBE);
                if(!String.IsNullOrEmpty(oModel.oProveedorBE.VENDORID))
                    oModel.oComunBE.Flag = Constantes.FlagRegistro.Actualizar;
            }
            return View(oModel);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult Registrar(ProveedorModels pItem)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                if(ProveedorBL.Instancia.Proveedor_Ins(pItem.oProveedorBE) > 0)
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
using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.BL;
using IB2B.Localizacion.BL.BL;
using IB2B.Localizacion.UI.Helpers;
using IB2B.Localizacion.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI.Controllers
{
    public class AdministracionController : Controller
    {
        [OutputCache(Duration = 0)]
        public ActionResult ListarTipoMovimiento()
        {
            TipoMovimientoModel oModel = new TipoMovimientoModel();
            return View(oModel);
        }


        [OutputCache(Duration = 0)]
        public ActionResult ListaTipoMovimiento(String pRUC, String pRazonSocial)
        {
            try
            {
                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pRUC;
                oItemBE.Criterio02 = pRazonSocial;
                List<TipoMovimientoBE> vLItemBE = TipoMovimientoBL.Instancia.TipoMovimiento_Sel(oItemBE);
                foreach (TipoMovimientoBE o in vLItemBE)
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




        [OutputCache(Duration = 0)]
        public ActionResult RegistrarTipoMovimiento()
        {
            TipoMovimientoModel oModel = new TipoMovimientoModel();
            
            
            //oModel.oComunBE.Flag = Constantes.FlagRegistro.Insertar;
            //if (!String.IsNullOrEmpty(pClienteId))
            //{
            //    ComunBE obComunBE = new ComunBE();
            //    obComunBE.DocumentoId = pClienteId;
            //    oModel.oClienteBE = ClienteBL.Instancia.ClienteId_Sel(obComunBE);
            //    if (!String.IsNullOrEmpty(oModel.oClienteBE.CUSTNMBR))
            //        oModel.oComunBE.Flag = Constantes.FlagRegistro.Actualizar;
            //}
            return View(oModel);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult RegistrarTipoMovimiento(ClienteModels pItem)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                //if (ClienteBL.Instancia.Cliente_Ins(pItem.oClienteBE) > 0)
                //    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                //else
                //{
                //    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                //    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                //}
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }



        [OutputCache(Duration = 0)]
        public ActionResult RegistrarTipoOperacionBanco()
        {
            TipoConfiguracionModel oModel = new TipoConfiguracionModel();


            //oModel.oComunBE.Flag = Constantes.FlagRegistro.Insertar;
            //if (!String.IsNullOrEmpty(pClienteId))
            //{
            //    ComunBE obComunBE = new ComunBE();
            //    obComunBE.DocumentoId = pClienteId;
            //    oModel.oClienteBE = ClienteBL.Instancia.ClienteId_Sel(obComunBE);
            //    if (!String.IsNullOrEmpty(oModel.oClienteBE.CUSTNMBR))
            //        oModel.oComunBE.Flag = Constantes.FlagRegistro.Actualizar;
            //}
            return View(oModel);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult RegistrarTipoOperacionBanco(ClienteModels pItem)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                //if (ClienteBL.Instancia.Cliente_Ins(pItem.oClienteBE) > 0)
                //    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                //else
                //{
                //    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                //    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                //}
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }



        [OutputCache(Duration = 0)]
        public ActionResult ListaConfigLocalizacion()
        {
            ConfigLocalizacionModel oModel = new ConfigLocalizacionModel();
            return View(oModel);
        }


        [OutputCache(Duration = 0)]
        public ActionResult ListarConfigLocalizacion(String pRUC, String pRazonSocial)
        {
            try
            {
                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pRUC;
                oItemBE.Criterio02 = pRazonSocial;
                List<ConfigLocalizacionBE> vLItemBE = ConfigLocalizacionBL.Instancia.ListaTipoDocumento(oItemBE);
                foreach (ConfigLocalizacionBE o in vLItemBE)
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
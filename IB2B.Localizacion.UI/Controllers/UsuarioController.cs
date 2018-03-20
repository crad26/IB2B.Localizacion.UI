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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Listar()
        {
            UsuarioBE oUsuarioBE = new UsuarioBE();
            return View(oUsuarioBE);
        }

        [OutputCache(Duration = 0)]
        public ActionResult Registrar(String pUsuarioId)
        {
            UsuarioBE pUsuarioModel = new UsuarioBE();
            if (!String.IsNullOrEmpty(pUsuarioId))
            {
                pUsuarioModel = UsuarioBL.Instancia.UsuarioId_Sel(pUsuarioId);
                pUsuarioModel.Flag = Constantes.FlagRegistro.Actualizar;
            }
            else
                pUsuarioModel.Flag = Constantes.FlagRegistro.Insertar;
            return View(pUsuarioModel);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult Registrar(UsuarioBE pUsuarioModel)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                if (UsuarioBL.Instancia.RegistrarUsuario(pUsuarioModel) > 0)
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeCorrectamente;
                }
                else
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                }
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 0)]
        public ActionResult ListaUsuarioCriterio(String pUsuarioId, String pNombre_Usu)
        {
            try
            {
                List<UsuarioBE> vLUsuarioBE = UsuarioBL.Instancia.UsuarioCriterio_Sel(pUsuarioId, pNombre_Usu);
                foreach (UsuarioBE o in vLUsuarioBE)
                {
                    o.Url_Detalle = HtmlExtensionHelpers.UrlEncodedActionLink(null, "Registrar", Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"]) + "Usuario", new { pUsuarioId = o.UsuarioId }).ToString();
                }
                var jsonResult = Json(vLUsuarioBE, JsonRequestBehavior.AllowGet);
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
        public ActionResult ValidarRegistrar(String pUsuarioId)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                String nResultado = UsuarioBL.Instancia.ValidarUsuario_Ins(pUsuarioId);
                if (String.IsNullOrEmpty(nResultado))
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                else
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                    obMensajeResultadoBE.Mensaje = nResultado;
                }
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 0)]
        public ActionResult EliminarUsuario(String pUsuarioId)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                if (UsuarioBL.Instancia.Usuario_Del(pUsuarioId) > 0)
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeCorrectamente;
                }
                else
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                }
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }
    }
}
using IB2B.Localizacion.UI.Helpers;
using IB2B.Localizacion.UI.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IB2B.Localizacion.BE.BE;
using IB2B.Localizacion.BL.BL;

namespace IB2B.Localizacion.UI.Controllers
{
    public class SistemaController : Controller
    {
        // GET: Sistema
        [AllowAnonymous]
        [FilterSessionCheck(NotVerifyMethod = true)]
        public ActionResult Login()
        {
            UsuarioBE obUsuarioBE = new UsuarioBE();
            return View(obUsuarioBE);
        }

        [AllowAnonymous]
        [FilterSessionCheck(NotVerifyMethod = true)]
        public JsonResult IngresoSistema(UsuarioBE pUsuarioBE)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                UsuarioBE obUsuarioBE = SistemaBL.Instancia.IngresoSistema(pUsuarioBE);
                if (!String.IsNullOrEmpty(obUsuarioBE.UsuarioId))
                {
                    List<MensajeResultadoBE> vLMensajeResultadoBE = new List<MensajeResultadoBE>();
                    String vPath = Server.MapPath("~/App_Data/" + obUsuarioBE.UsuarioId);
                    if (!Directory.Exists(vPath))
                        Directory.CreateDirectory(vPath);
                    else
                    {
                        String[] vFilePaths = Directory.GetFiles(vPath);
                        foreach (String nFilePath in vFilePaths)
                        {
                            System.IO.File.Delete(nFilePath);
                        }
                    }
                    Session[Constantes.GrupoLocalizacion.UsuarioSesionId] = obUsuarioBE.UsuarioId;
                    Session[Constantes.GrupoLocalizacion.UsuarioConectado] = obUsuarioBE.Usuario_Usu;
                    Session[Constantes.GrupoLocalizacion.LogoString] = Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Imagen/DIRESA.png")));
                    List<MenuBE> vLMenuAccesos = MenuBL.Instancia.Menu_Sel();
                    if (vLMenuAccesos.Count > 0)
                    {
                        Session[Constantes.GrupoLocalizacion.Menu] = vLMenuAccesos;
                        Session[obUsuarioBE.UsuarioId] = obUsuarioBE;
                        obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Ok;
                    }
                }
                else
                {
                    obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                    obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.UsuarioIncorrecto;
                }
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                obMensajeResultadoBE.Mensaje = ex.Message;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Inicio()
        {
            UsuarioBE ogUsuarioBE = new UsuarioBE();
            ogUsuarioBE.UsuarioId = "vbolarte";
            ogUsuarioBE.Usuario_Usu = "victor bolarte";
            Session[Constantes.GrupoLocalizacion.UsuarioSesionId] = ogUsuarioBE.UsuarioId;
            Session[Constantes.GrupoLocalizacion.UsuarioConectado] = ogUsuarioBE.Usuario_Usu;


            List<MenuBE> vLMenuAccesos = MenuBL.Instancia.Menu_Sel();
           
                Session[Constantes.GrupoLocalizacion.Menu] = vLMenuAccesos;
              
            return View();
        }
    }
}
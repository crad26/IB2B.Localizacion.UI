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
using IB2B.Localizacion.BE.Conection;
using Microsoft.OData.Client;
using System.Resources;
using System.Text.RegularExpressions;
using IB2B.Localizacion.DAC.DAC;

namespace IB2B.Localizacion.UI.Controllers
{
    public class ClienteController : Controller
    {
        public static string ODataEntityPath = IB2B.Localizacion.BE.Conection.ClientConfiguration.Default.UriString + "data";
        // GET: Cliente
        [OutputCache(Duration = 0)]
        public ActionResult Listar()
        {


            ClienteModels oModel = new ClienteModels();
            return View(oModel);
        }

        [OutputCache(Duration = 0)]
        public ActionResult ListaClienteCriterio(String pRUC, String pRazonSocial)
        {
            try
            {

                ComunBE oItemBE = new ComunBE();
                oItemBE.Criterio01 = pRUC;
                oItemBE.Criterio02 = pRazonSocial;
                List<BE.BE.ClienteBE> vLItemBE = ClienteBL.Instancia.ClienteCriterio_Sel(oItemBE);
                foreach (BE.BE.ClienteBE o in vLItemBE)
                {
                    o.Url_Detalle = HtmlExtensionHelpers.UrlEncodedActionLink(null, "Registrar", Convert.ToString(ConfigurationManager.AppSettings["NombreIIS"]) + "Cliente", new { pClienteId = o.CUSTNMBR }).ToString();
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
        public ActionResult Registrar(String pClienteId)
        {
            ClienteModels oModel = new ClienteModels();
            oModel.vLTipoDocumentoBE = TipoDocumentoBL.Instancia.TipoDocumento_Sel();
            oModel.vLTipoPersonaBE = TipoPersonaBL.Instancia.TipoPersona_Sel();
            oModel.oComunBE.Flag = Constantes.FlagRegistro.Insertar;
            if (!String.IsNullOrEmpty(pClienteId))
            {
                ComunBE obComunBE = new ComunBE();
                obComunBE.DocumentoId = pClienteId;
                oModel.oClienteBE = ClienteBL.Instancia.ClienteId_Sel(obComunBE);
                if (!String.IsNullOrEmpty(oModel.oClienteBE.CUSTNMBR))
                    oModel.oComunBE.Flag = Constantes.FlagRegistro.Actualizar;
            }
            return View(oModel);
        }


        //[HttpPost]
        //[OutputCache(Duration = 0)]
        //public ActionResult Registrar(ClienteModels pItem)
        //{
        //    MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
        //    try
        //    {
        //        TipoPersonaBL.Instancia.TipoPersona_Sel();
        //        ClienteBE obClienteBE = new ClienteBE();
        //        obClienteBE.CUSTNMBR = pItem.oClienteBE.CUSTNMBR;
        //        obClienteBE.CUSTNAME = pItem.oClienteBE.CUSTNAME;
        //        obClienteBE.oTipoPersonaBE.TipoPersonaID = pItem.oClienteBE.oTipoPersonaBE.TipoPersonaID;
        //        obClienteBE.oTipoPersonaBE.TipoPersonaNombre = pItem.oClienteBE.oTipoPersonaBE.TipoPersonaNombre;
        //        obClienteBE.oTipoDocumentoBE.TipoDocumentoID = pItem.oClienteBE.oTipoDocumentoBE.TipoDocumentoID;
        //        obClienteBE.oTipoDocumentoBE.TipoDocumentoNombre = pItem.oClienteBE.oTipoDocumentoBE.TipoDocumentoNombre;
        //        obClienteBE.TB_NRO_DOCUMENTO = pItem.oClienteBE.TB_NRO_DOCUMENTO;
        //        obClienteBE.TB_REFERENCIA = pItem.oClienteBE.TB_REFERENCIA;
        //        obClienteBE.TB_RAZON_SOCIAL = pItem.oClienteBE.TB_RAZON_SOCIAL;
        //        obClienteBE.FRSTNAME = pItem.oClienteBE.FRSTNAME;
        //        obClienteBE.SHRTNAME = pItem.oClienteBE.SHRTNAME;
        //        obClienteBE.LASTNAME = pItem.oClienteBE.LASTNAME;
        //        obClienteBE.MIDLNAME = pItem.oClienteBE.MIDLNAME;

        //        obClienteBE.CB_BC = pItem.oClienteBE.CB_BC;
        //        obClienteBE.DT_BC_FECHA1 = pItem.oClienteBE.DT_BC_FECHA1;

        //        obClienteBE.CB_AR = pItem.oClienteBE.CB_AR;
        //        obClienteBE.DT_AR_FECHA1 = pItem.oClienteBE.DT_AR_FECHA1;

        //        obClienteBE.CB_AP = pItem.oClienteBE.CB_AP;
        //        obClienteBE.DT_AP_FECHA1 = pItem.oClienteBE.DT_AP_FECHA1;

        //        obClienteBE.CB_RI = pItem.oClienteBE.CB_RI;
        //        obClienteBE.DT_RI_FECHA1 = pItem.oClienteBE.DT_RI_FECHA1;

        //        obClienteBE.CB_NH = pItem.oClienteBE.CB_NH;
        //        obClienteBE.DT_NH_FECHA1 = pItem.oClienteBE.DT_NH_FECHA1;



        //        int validar = ClienteBL.Instancia.Cliente_Ins(obClienteBE);


        //    }
        //    catch (Exception ex)
        //    {
        //        obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
        //        obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
        //    }
        //    obMensajeResultadoBE.Resultado = Constantes.MensajeLocalizacion.MensajeCorrectamente;
        //    return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        //}



        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult Registrar(ClienteModels pItem)
        {
            MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
            try
            {
                ClienteModels oModel = new ClienteModels();
                oModel.vLTipoDocumentoBE = TipoDocumentoBL.Instancia.TipoDocumento_Sel();
                oModel.vLTipoPersonaBE = TipoPersonaBL.Instancia.TipoPersona_Sel();

                ServiceReference1.ClienteBE pClienteBE = new ServiceReference1.ClienteBE();
                pClienteBE.ClienteID = pItem.oClienteBE.CUSTNMBR;
                pClienteBE.Name = pItem.oClienteBE.CUSTNAME;
                ServiceReference1.ResultadoBE ob = new ServiceReference1.LocalizacionClient().RegistrarCliente(pClienteBE, "FI");
            }
            catch (Exception ex)
            {
                obMensajeResultadoBE.Mensaje = Constantes.MensajeLocalizacion.MensajeError;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
            }
            return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
        }


        [OutputCache(Duration = 0)]
        public ActionResult ConsultaSUNAT(String pDocumentoId)
        {
            try
            {
                ServiceReference1.DatosSUNATBE obDatosSUNAT = new ServiceReference1.LocalizacionClient().GetDataSUNAT(pDocumentoId.ToString().Trim());
               // ServiceReferenceEjemplo.ServiceRUCPortTypeClient o = new ServiceReferenceEjemplo.ServiceRUCPortTypeClient().


                ClienteBE obItemBE = new ClienteBE();

                obItemBE.TB_NRO_DOCUMENTO = pDocumentoId;
                obItemBE.TB_RAZON_SOCIAL = obDatosSUNAT.RazonSocial;
                obItemBE.CB_BC = false;

                if (pDocumentoId[0].ToString() == "2")
                {
                    obItemBE.TB_NRO_DOCUMENTO = pDocumentoId;
                    obItemBE.TB_RAZON_SOCIAL = obDatosSUNAT.RazonSocial;
                    obItemBE.CUSTNAME = obDatosSUNAT.RazonSocial;

                    obItemBE.oTipoPersonaBE.TipoPersonaID = "02";
                    obItemBE.oTipoDocumentoBE.TipoDocumentoID = "06";
                    //string mensaje = "PERSONA JURIDICA";
                }
                else
                {
                    try
                    {

                        string[] cadena = obDatosSUNAT.NombreNatural.Split(new string[] { "-" }, StringSplitOptions.None);

                        string[] primeraCadena = cadena[0].ToString().Trim().Split(new string[] { "DNI" }, StringSplitOptions.None);
                        string DNIPersonaNatural = primeraCadena[1].ToString().Trim();


                        //string[] segundaCadena = cadena[1].ToString().Trim().Split(new string[] { "," }, StringSplitOptions.None);

                        //string NombrePersonaNatural = segundaCadena[0].ToString();
                        //string ApellidoPersonaNatural = segundaCadena[1].ToString();



                        string[] res = obDatosSUNAT.RazonSocial.Split(new string[] { " " }, StringSplitOptions.None);

                        obItemBE.TB_NRO_DOCUMENTO = DNIPersonaNatural;
                        obItemBE.oTipoPersonaBE.TipoPersonaID = "01";
                        obItemBE.oTipoDocumentoBE.TipoDocumentoID = "01";

                        obItemBE.CUSTNAME = "";
                        obItemBE.TB_RAZON_SOCIAL = "";
                        obItemBE.FRSTNAME = res[0];
                        obItemBE.SHRTNAME = res[1];
                        obItemBE.LASTNAME = res[2];
                        obItemBE.MIDLNAME = res[3];
                        //string mensaje2 = "PERSONA NATURAL";
                    }
                    catch (Exception ex)
                    {

                    }
                }
                var jsonResult = Json(obItemBE, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = Int32.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                MensajeResultadoBE obMensajeResultadoBE = new MensajeResultadoBE();
                obMensajeResultadoBE.Mensaje = ex.Message;
                obMensajeResultadoBE.Resultado = Constantes.ResultadoSistema.Error;
                return Json(obMensajeResultadoBE, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
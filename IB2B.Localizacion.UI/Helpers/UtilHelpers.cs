using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
using System.IO;
using System.Configuration;
using System.IO.Compression;
using System.Xml;
using System.Text;
using IB2B.Localizacion.BE.BE;

namespace IB2B.Localizacion.UI.Helpers
{
    public class UtilHelpers
    {
        public static UsuarioBE ObtenerDatosUsuario()
        {
            String cIdUsuarioConnectado = Convert.ToString(HttpContext.Current.Session[Constantes.GrupoLocalizacion.UsuarioSesionId]);
            UsuarioBE obUsuarioBE = HttpContext.Current.Session[cIdUsuarioConnectado] as UsuarioBE;
            return obUsuarioBE;
        }

        public static String FechaCorrecta(DateTime pFecha)
        {
            return pFecha.Year.ToString() + pFecha.Month.ToString().PadLeft(2, '0') + pFecha.Day.ToString().PadLeft(2, '0');
        }

        public static String FechaCorrectaString(String pFecha)
        {
            return pFecha.Split('-')[2] + pFecha.Split('-')[1] + pFecha.Split('-')[0];
        }

        public static String FechaCita(DateTime pFecha)
        {
            return String.Format("{0}-{1}-{2} 00:00:00.000", pFecha.Year, pFecha.Month, pFecha.Day);
        }

        public static String FechaDatapicker(DateTime pFecha)
        {
            return String.Format("{0}-{1}-{2}", pFecha.Day.ToString().PadLeft(2, '0'), pFecha.Month.ToString().PadLeft(2, '0'), pFecha.Year);
        }

        public static String HoraCita(String pFecha, String pHora)
        {
            return pFecha.Replace("00:00:00", pHora + ":00");
        }

        public static void CrearLog(Exception pException, String pErrorPersonalizado, Boolean pEnviarCorreo, String pProcesoId)
        {
            //UsuarioBE obUsuarioBE = ObtenerDatosUsuario();
            //LogBE obLogBE = new LogBE();
            //obLogBE.Compania = obUsuarioBE.oCompaniaBE.RazonSocial_Cia;
            //obLogBE.EnviarEmail = pEnviarCorreo;
            //obLogBE.ErrorPersonalizado = pErrorPersonalizado;
            //obLogBE.PathLog = HttpContext.Current.Server.MapPath("~/Log_Informacion");
            //obLogBE.PlantillaHTML = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~" + @"\PlantillasEmail\Tmp_Log.html"));
            //obLogBE.ProcesoId = pProcesoId;
            //LogExceptionHelper.EscribirLog(pException, obLogBE);
        }

    }
}
<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using IB2B.Localizacion.BE.BE;

public class FileUploadHandler : IHttpHandler, IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        if (context.Request.Files.Count > 0)
        {
            String cgUsuarioId = Convert.ToString(context.Session[IB2B.Localizacion.BE.BE.Constantes.GrupoLocalizacion.UsuarioSesionId]);
            UsuarioBE obUsuarioBE = (UsuarioBE)context.Session[cgUsuarioId];
              //  UsuarioBE obj =new  UsuarioBE();
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                using (System.IO.Stream stream = file.InputStream)
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                   // obUsuarioBE.byteLogo = imageToByteArray(image);
                    context.Session[cgUsuarioId] = obUsuarioBE;
                }
            }
            context.Response.ContentType = "text/plain";
        }
    }

    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        using (var ms = new System.IO.MemoryStream())
        {
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}
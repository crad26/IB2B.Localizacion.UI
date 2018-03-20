using IB2B.Localizacion.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI.Controllers
{
    public class PagoMasivoController : Controller
    {
        // GET: PagoMasivo
        public ActionResult Listar()
        {
            PagoMasivoModels oModel = new PagoMasivoModels();
            return View(oModel);
        }

        public ActionResult Registrar()
        {
            PagoMasivoModels oModel = new PagoMasivoModels();
            return View(oModel);
        }
    }
}
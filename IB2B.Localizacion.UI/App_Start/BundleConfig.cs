using System.Web;
using System.Web.Optimization;

namespace IB2B.Localizacion.UI
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js",
                        "~/Scripts/App/app.js",
                        "~/Scripts/App/demo.js",
                        "~/Scripts/App/Efacturacion.js",
                        "~/Scripts/plugins/bootbox/bootbox.min.js",
                        "~/Scripts/plugins/jqGrid/jquery.jqGrid.min.js",
                        "~/Scripts/plugins/jqGrid/i18n/grid.locale-en.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/jquery.fileupload.js",
                        "~/Scripts/jquery.ui.widget.js",
                        "~/Scripts/plugins/iCheck/icheck.min.js",
                        "~/Scripts/App/ES_Util.js",
                        "~/Scripts/validarCampos.js",
                        "~/Scripts/plugins/jquery-ui/i18n/jquery.ui.datepicker-es.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobstrusive").Include(
               "~/Scripts/jquery.validate.min.js",
               "~/Scripts/jquery.unobtrusive-ajax.min.js",
               "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins").Include(
                      "~/Content/plugins/iCheck/custom.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));
        }
    }
}

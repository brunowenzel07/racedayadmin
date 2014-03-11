using System.Globalization;
using System.Web;
using System.Web.Optimization;

namespace RaceData.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/kendo.all.js")
                .Include("~/Scripts/kendo.aspnetmvc.js")
                .Include("~/Scripts/jquery-migrate-1.2.1.js")
                .Include("~/Scripts/helper.js")
                .Include("~/Scripts/bootstrapSwitch.js")
                .Include(string.Format("~/Scripts/kendo.culture.{0}.js", CultureInfo.CurrentCulture))
             );

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

             bundles.Add(new ScriptBundle("~/bundles/jqueryvalajax")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js"));
          

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-theme.css")
                .Include("~/Content/bootstrapSwitch.css")
                .Include("~/Content/login.css")
                .Include("~/Content/kendo.bootstrap.css")
                .Include("~/Content/kendo.common-bootstrap.css")
                .Include("~/Content/kendo.common.css"));

         

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
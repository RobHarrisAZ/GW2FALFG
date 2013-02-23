using System.Web;
using System.Web.Optimization;

namespace GW2FALFG.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                        "~/Scripts/vendor/jquery-{version}.js",
                        "~/Scripts/vendor/bootstrap.min.js",
                        "~/Scripts/vendor/modernizr-*",
                        "~/Scripts/vendor/angular/angular.min.js",
                        "~/Scripts/vendor/ng-grid-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            //"~/Scripts/app.js",
            //"~/Scripts/services/CookieService.js",
            //"~/Scripts/controllers/LFGCtrl.js",
            //"~/Scripts/directives/editableDir.js",
            //"~/Scripts/filters/timefilter.js"

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/bootstrap.min.css",
                "~/Content/ng-grid.css"
                ));    
        }
    }
}

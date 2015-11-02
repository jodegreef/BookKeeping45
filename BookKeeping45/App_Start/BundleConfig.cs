using System.Web;
using System.Web.Optimization;

namespace BookKeeping45
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ut-router.js",
                "~/Scripts/ui-bootstrap-tpls-0.14.3.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angularapp").Include(
                "~/Scripts/bookkeeping.app.js"
                , "~/Scripts/bookkeeping.service.js"
                , "~/Scripts/bookkeeping.controller.js"
                , "~/Scripts/bookkeeping.add.controller.js"
                , "~/Scripts/bookkeeping.edit.controller.js"
                , "~/Scripts/bookkeeping.markassold.controller.js"
                , "~/Scripts/bookkeeping.legosetdetail.directive.js"

                ));


            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                "~/Scripts/notify.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/site.css"));
        }
    }
}

namespace PoC.WebUI
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                        "~/Content/bootstrap/theme.css"));

            bundles.Add(new StyleBundle("~/Content/css/dataTables").Include(
                        "~/Content/dataTables/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/sweetalert").Include(
                       "~/Content/sweetalert/sweetalert.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/jquery-ui.min.css",
                        "~/Content/main.css",
                        "~/Content/vendor.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/mascara").Include(
                        "~/Scripts/mascaras.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                        "~/Scripts/vendor.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                        "~/Scripts/vendor/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/dataTables/datatables.min.js",
                        "~/Scripts/dataTables/dataTables.bootstrap4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                        "~/Scripts/sweetalert/sweetalert.min.js"));
        }
    }
}

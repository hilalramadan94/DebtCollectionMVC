using System.Web;
using System.Web.Optimization;

namespace DebtCollectionMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js",
                        //"~/Scripts/bootstrap-mod.js",
                        //"~/Scripts/respond.js",
                        //"~/Scripts/metisMenu.js",
                        //"~/Scripts/sb-admin-2.js",
                        //MOD
                        "~/Scripts/mod/jquery-2.2.4.min.js",
                        "~/Scripts/mod/popper.min.js",
                        "~/Scripts/mod/bootstrap.min.js",
                        "~/Scripts/mod/owl.carousel.min.js",
                        "~/Scripts/mod/metisMenu.min.js",
                        "~/Scripts/mod/jquery.slimscroll.min.js",
                        "~/Scripts/mod/jquery.slicknav.min.js",
                        "~/Scripts/mod/line-chart.js",
                        "~/Scripts/mod/pie-chart.js",
                        "~/Scripts/mod/plugins.js",
                        "~/Scripts/mod/scripts.js",
                        "~/Scripts/mod/bootstrap-datepicker.js",
                        //-----------
                        "~/scripts/bootbox.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap4.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/bootstrap-mod.css", //edit
                //"~/Content/site.css",
                //Tambahan
                //"~/Content/font-awesome.css",
                //"~/Content/metisMenu.css",
                //"~/Content/sb-admin-2.css",
                "~/Content/mod/bootstrap.min.css",
                "~/Content/mod/font-awesome.min.css",
                "~/Content/mod/themify-icons.css",
                "~/Content/mod/metisMenu.css",
                "~/Content/mod/owl.carousel.min.css",
                "~/Content/mod/slicknav.min.css",
                "~/Content/mod/typography.css",
                "~/Content/mod/default-css.css",
                "~/Content/mod/styles.css",
                "~/Content/mod/responsive.css",
                "~/Content/mod/bootstrap-datepicker.css",
                "~/Content/datatables/css/datatables.bootstrap4.css"));
        }
    }
}

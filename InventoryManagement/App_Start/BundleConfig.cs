using System.Web;
using System.Web.Optimization;

namespace InventoryManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Content/bower_components/jquery/dist/jquery.min.js"));


            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform()
            ));
            // font-awesome Styles
            bundles.Add(new StyleBundle("~/Content/fontawesomeCss")
                .Include("~/Content/bower_components/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
            )
            .Include("~/Content/bower_components/Ionicons/css/ionicons.min.css", new CssRewriteUrlTransform()
            )
            .Include("~/Content/bower_components/jvectormap/jquery-jvectormap.css", new CssRewriteUrlTransform()
            )
            );

            // bootstrap datepicker Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapdatepickerCss")
                .Include("~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css", new CssRewriteUrlTransform())
                );

            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/plugins/iCheck/all.css",
                "~/Content/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                "~/Content/bower_components/select2/dist/css/select2.min.css",
                "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                "~/Content/dist/css/AdminLTE.min.css",
                "~/Content/dist/css/skins/_all-skins.min.css"
            ));

            //Script
            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
              "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
              "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
              "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
              "~/Content/bower_components/select2/dist/js/select2.full.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Inputmask").Include(
                      "~/Content/plugins/input-mask/jquery.inputmask.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.extensions.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Datepicker").Include(
                      "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                      "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                      "~/Content/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                      "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Content/plugins/iCheck/icheck.min.js",
                      "~/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Content/dist/js/adminlte.min.js",
                      "~/Content/dist/js/demo.js"
                      
            ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/bower_components/moment/min/moment.min.js"
            ));
            BundleTable.EnableOptimizations = true;
        }
    }
}

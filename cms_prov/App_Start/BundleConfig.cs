using System.Web;
using System.Web.Optimization;

namespace cms_prov
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/css/styles").Include(
               "~/css/bootstrap.css",
               "~/css/owlcarousel.css",
               "~/css/mixitup.css",

               "~/css/owltheme.css",
               "~/css/globalstyle.css",
               "~/css/style.css",
               "~/css/fancybox.css",
               "~/css/layerslider.css"
               ));

            bundles.Add(new StyleBundle("~/fontawesome/css/font").Include(
                "~/fontawesome/css/fontawesome.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ui").Include(
                      "~/js/jquery1.js",
                      "~/js/app.js",
                      "~/js/jquerymixitup.js",
                      "~/js/jquerymixitupinit.js",

                      "~/js/jqueryfancyboxpack.js",
                      "~/js/owlcarousel.js",
                      "~/js/jquerystellar.js",
                      "~/js/greensock.js",
                      "~/js/layerslidertransitions.js",
                      "~/js/layersliderkreaturamedia.js"));
          
            BundleTable.EnableOptimizations = true;
        }
        
    }
}

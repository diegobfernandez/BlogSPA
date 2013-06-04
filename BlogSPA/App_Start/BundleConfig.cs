using System.Web.Optimization;

namespace BlogSPA.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/libs")
                .Include("~/libs/angular-1.1.5.js")
                .Include("~/libs/angular-ui-bootstrap-0.3.0.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/style").Include("~/style/bootstrap-2.3.2.css"));
        }
    }
}
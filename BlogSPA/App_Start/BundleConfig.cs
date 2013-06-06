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
                .IncludeDirectory("~/libs", "*.js"));

            bundles.Add(new ScriptBundle("~/bundle/app")
                .IncludeDirectory("~/commom/", "*.js", true)
                .IncludeDirectory("~/app/", "*.js", true));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/style").Include("~/content/style/bootstrap-2.3.2.css"));
        }
    }
}
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
            bundles.Add(new ScriptBundle("~/bundle/libs").IncludeDirectory("~/libs", "*.js"));
            bundles.Add(new ScriptBundle("~/bundle/app").IncludeDirectory("~/commom/", "*.js", true).IncludeDirectory("~/app/", "*.js", true));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/style")
                .IncludeDirectory("~/content/style/libs", "*.css")
                .IncludeDirectory("~/content/style", "*.css"));
        }
    }
}
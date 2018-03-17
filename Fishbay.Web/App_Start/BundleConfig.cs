using System.Web;
using System.Web.Optimization;

namespace Fishbay.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.js", "~/js/default.js"));

            bundles.Add(new StyleBundle("~/css/default").Include(
                      "~/css/bootstrap.css",
                      "~/css/default.css"));
        }
    }
}

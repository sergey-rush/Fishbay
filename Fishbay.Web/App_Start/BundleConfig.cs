using System.Web;
using System.Web.Optimization;

namespace Fishbay.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/js/bootstrap.bundle.js", "~/js/default.js"));

            // editor
            bundles.Add(new ScriptBundle("~/bundles/editor").Include("~/js/summernote.min.js", "~/js/summernote-ru-RU.js"));
            bundles.Add(new StyleBundle("~/css/editor").Include("~/css/summernote.css"));

            bundles.Add(new StyleBundle("~/css/default").Include("~/css/bootstrap.css","~/css/default.css"));
        }
    }
}

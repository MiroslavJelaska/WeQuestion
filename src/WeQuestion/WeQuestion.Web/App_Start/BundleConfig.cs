using System.Web.Optimization;

namespace WeQuestion.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/libs")
            .Include(
                "~/Scripts/libs/modernizr-2.6.2.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/app")
            .Include(
                "~/Scripts/libs/modernizr-2.6.2.js"
            ));
        }
    }
}

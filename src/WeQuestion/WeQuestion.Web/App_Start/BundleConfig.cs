using System.Web.Optimization;

namespace WeQuestion.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/libs")
            .Include(
                "~/Scripts/libs/modernizr-2.6.2.js",
                "~/Scripts/libs/js-enumeration-v.0.2.3.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/app")
            .Include(
                "~/Scripts/app/app.module.js",
                "~/Scripts/app/app.config.js",

                "~/Scripts/app/common/constants/surveyState.js",

                "~/Scripts/app/common/services/surveyService.js",

                "~/Scripts/app/admin/admin.state.js",
                "~/Scripts/app/admin/admin.create.controller.js",
                "~/Scripts/app/admin/admin.create.state.js",
                "~/Scripts/app/admin/admin.survey.controller.js",
                "~/Scripts/app/admin/admin.survey.state.js",
                "~/Scripts/app/admin/admin.statePanel.controller.js",
                "~/Scripts/app/admin/admin.stateOpen.state.js",
                "~/Scripts/app/admin/admin.stateClosed.state.js",
                "~/Scripts/app/admin/admin.stateProvisional.state.js"
            ));
        }
    }
}

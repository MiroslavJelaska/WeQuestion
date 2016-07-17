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
                "~/Scripts/libs/js-enumeration-v.0.2.3.js",
                "~/Scripts/libs/angular-ui-tree/angular-ui-tree.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/app")
            .Include(
                "~/Scripts/app/app.module.js",
                "~/Scripts/app/app.config.js",

                "~/Scripts/app/common/constants/surveyState.js",

                "~/Scripts/app/common/filters/numberToLetter.js",
                "~/Scripts/app/common/filters/durationLabel.js",

                "~/Scripts/app/common/services/surveyService.js",

                "~/Scripts/app/common/directives/closingCountdown.js",

                "~/Scripts/app/admin/state.js",
                "~/Scripts/app/admin/create.controller.js",
                "~/Scripts/app/admin/create.state.js",
                "~/Scripts/app/admin/edit.controller.js",
                "~/Scripts/app/admin/edit.state.js",
                "~/Scripts/app/admin/manage.controller.js",
                "~/Scripts/app/admin/manage.state.js",
                "~/Scripts/app/admin/survey.controller.js",
                "~/Scripts/app/admin/survey-header.controller.js",
                "~/Scripts/app/admin/survey.state.js",
                "~/Scripts/app/admin/statePanel.controller.js",
                "~/Scripts/app/admin/stateOpen.state.js",
                "~/Scripts/app/admin/stateClosed.state.js",
                "~/Scripts/app/admin/stateProvisional.state.js"
            ));
        }
    }
}

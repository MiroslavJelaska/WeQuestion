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

                "~/Scripts/app/admin/admin.state.js",
                "~/Scripts/app/admin/createOrEdit/create.controller.js",
                "~/Scripts/app/admin/createOrEdit/create.state.js",
                "~/Scripts/app/admin/createOrEdit/edit.controller.js",
                "~/Scripts/app/admin/createOrEdit/edit.state.js",
                "~/Scripts/app/admin/manage/manage.controller.js",
                "~/Scripts/app/admin/manage/manage.state.js",
                "~/Scripts/app/admin/survey/survey.controller.js",
                "~/Scripts/app/admin/survey/survey-header.controller.js",
                "~/Scripts/app/admin/survey/survey.state.js",
                "~/Scripts/app/admin/statePanel/statePanel.controller.js",
                "~/Scripts/app/admin/statePanel/stateOpen.state.js",
                "~/Scripts/app/admin/statePanel/stateClosed.state.js",
                "~/Scripts/app/admin/statePanel/stateProvisional.state.js",

                "~/Scripts/app/participant/participant.state.js",
                "~/Scripts/app/participant/participant.controller.js"
            ));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace YouthConference
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui/jquery.ui*"));
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                       "~/Scripts/chosen/chosen.jquery,min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/application").Include("~/Scripts/application*", "~/Scripts/bootstrap*", "~/Scripts/demonstration*", "~/Scripts/eakroko*", "~/Scripts/jquery.signalR-1.1.2.js"));
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include("~/Content/smoothness/jquery.ui.css", "~/Content/smoothness/jquery.ui.theme.css"));
            bundles.Add(new StyleBundle("~/Content/chosen").Include("~/Content/chosen/chosen.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap*", "~/Content/themes*", "~/Content/PagedList.css", "~/Content/font*", "~/Content/style.css"));

        }
    }
}
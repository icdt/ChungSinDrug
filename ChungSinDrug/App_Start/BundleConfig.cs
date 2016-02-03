using System.Web;
using System.Web.Optimization;

namespace icdtFramework.Configs
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/metisMenu.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/site.css", 
                      "~/Content/PagedList.css",
                      "~/Content/BackendStyle.css"));

            bundles.Add(new StyleBundle("~/admin/theme/css").Include(
                      "~/Content/metisMenu.css",
                      "~/Content/sb-admin-2.css"));

            bundles.Add(new ScriptBundle("~/admin/theme/js").Include(
                      "~/Scripts/metisMenu.js",
                      "~/Scripts/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/icdtFramework/plugins/js").Include(
                      "~/icdtFramework/Plugins/datepicker/dialogUI.js",
                      "~/icdtFramework/Plugins/datepicker/jquery.ui.datepicker-zh-TW.js",
                      "~/icdtFramework/Plugins/uploadify/jquery.uploadify-3.1.min.js",
                      "~/icdtFramework/Plugins/ckeditor/ckeditor.js"));

            bundles.Add(new StyleBundle("~/icdtFramework/plugins/css").Include(
                      "~/icdtFramework/Plugins/datepicker/dislog.css",
                      "~/icdtFramework/Plugins/uploadify/uploadify.css",
                      "~/icdtFramework/Plugins/kendo/kendo.common.min.css",
                      "~/icdtFramework/Plugins/kendo/kendo.default.min.css"));
        }
    }
}

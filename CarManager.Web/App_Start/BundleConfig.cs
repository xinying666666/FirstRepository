﻿using System.Web;
using System.Web.Optimization;

namespace CarManager.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));//代表用最新的版本

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.UseCdn = BundleTable.EnableOptimizations = true;

            //bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/Scripts/Jquery-Validate").Include("~/Scripts/jquery.validate.min.js"));
            //bundles.Add(new ScriptBundle("~/Scripts/Jquery-Validate-Unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js"));
            

            bundles.Add(new StyleBundle("~/Style/Bootstrap").Include("~/AceLib/assets/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Style/Font-Awesome","//cdn.bootcss.com/font-awesome/4.6.3/css/font-awesome.min.css").Include("~/AceLib/assets/font-awesome/4.2.0/css/font-awesome.min.css"));
            // bundles.Add(new StyleBundle("~/Style/Font-Awesome").Include("~/AceLib/assets/font-awesome/4.2.0/css/font-awesome.min.css"));//使用下面这个无法显示页面上的图片
           

            bundles.Add(new StyleBundle("~/Style/Fonts-Googleapis").Include("~/AceLib/assets/fonts/fonts.googleapis.com.css"));
            bundles.Add(new StyleBundle("~/Style/Ace-Template").Include("~/AceLib/assets/css/ace.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Extra").Include("~/AceLib/assets/js/ace-extra.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Html5shiv").Include("~/AceLib/assets/js/html5shiv.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Respond").Include("~/AceLib/assets/js/respond.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/AceLib/assets/js/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include("~/AceLib/assets/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Ace-Elements").Include("~/AceLib/assets/js/ace-elements.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Ace").Include("~/AceLib/assets/js/ace.min.js"));
          

        }
    }
}

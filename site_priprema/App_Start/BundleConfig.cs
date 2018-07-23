using System.Web;
using System.Web.Optimization;

namespace site_priprema
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
				  "~/Content/Styles/font-awesome.css",
				  "~/Content/Styles/bootstrap.min.css",
				  "~/Content/Styles/animate.min.css",
				  "~/Content/Styles/owl.carousel.css",
				  "~/Content/Styles/owl.theme.css",
				  "~/Content/Styles/style.default.css",
					"~/Content/Styles/custom.css"
				));
            bundles.Add(new ScriptBundle("~/bundles/Additional/Script-custom-editor").Include(
                       "~/Scripts/Additional/script-custom-editor.js"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
				"~/Scripts/Additional/jquery-1.11.0.min.js",
				"~/Scripts/Additional/bootstrap.min.js",
				"~/Scripts/Additional/custom.js",
				"~/Scripts/Additional/jquery.cookie.js",
				"~/Scripts/Additional/waypoints.min.js",
				"~/Scripts/Additional/modernizr.js",
				"~/Scripts/Additional/bootstrap-hover-dropdown.js",
				"~/Scripts/Additional/owl.carousel.min.js",
				"~/Scripts/Additional/front.js",
                "~/Scripts/Additional/script-custom-editor.js",
                "~/Scripts/Additional/ajax.js"
                ));
		}
	}
}

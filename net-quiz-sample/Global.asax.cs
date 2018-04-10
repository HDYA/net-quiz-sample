using net_quiz_sample.App_Start;
using net_quiz_sample.Context;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace net_quiz_sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DatabaseConfig.Configuration();
            Database.SetInitializer<QuizDbContext>(new DropCreateDatabaseIfModelChanges<QuizDbContext>());
            AppInsightsConfig.Configure();
        }
    }
}

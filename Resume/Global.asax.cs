using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Resume.GeneratorProviders;

namespace Resume
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ValueProviderFactories.Factories.Add(new GeneratorProviderFactory());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

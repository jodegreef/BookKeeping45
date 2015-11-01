using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using BookKeeping45.Mvc.FeatureFolders;
using BookKeeping45.Bootstrapper;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BookKeeping45.Features.Inventory;
using Autofac;

namespace BookKeeping45
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeatureViewLocationRazorViewEngine());


            var container = Bootstrap.Create(builder => {
                builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
                //builder.RegisterType<InventoryController>().InstancePerRequest();
                builder.RegisterControllers(typeof(MvcApplication).Assembly);
            });

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}

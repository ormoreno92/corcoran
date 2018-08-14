using Api.Logic;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IPresident, President>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

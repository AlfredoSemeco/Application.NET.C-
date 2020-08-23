using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMovie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*[RouteConfig]: Clase donde se define logica de enrutamiento de aplicativo*/

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes, en este caso define como pagina default(inicio): Controller: Home con action: Index (metodo(View)) */
            /*id: como valores de parametros posibles a enviar por URL(Controller) (Opcional)*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            /*Otra manera de definir parametro de URL para un controlador que utilice estas variables: name y numTimes*/
            routes.MapRoute(
          name: "anyName",
          url: "{controller}/{action}/{name}/{numTimes}"
      );
        }
    }
}

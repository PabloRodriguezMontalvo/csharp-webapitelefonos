using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTelefonos.Extensions;
using WebApiTelefonos.Models;

namespace WebApiTelefonos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;


            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new ManejadorMensajesAutenticacion(
                new VentaTelefonoEntities()));
            
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

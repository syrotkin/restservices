using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // you can add more routes here if you don't want to use the query string

            

            // TODO-osy: get Product by ID and Name -- so, both have to match
            
            // TOOD-osy: wrap a Read stored procedure and return a result. -- can use a local database

            // TODO-osy: wrap a Write stored procedure and return a result -- can use a local database
        }
    }
}

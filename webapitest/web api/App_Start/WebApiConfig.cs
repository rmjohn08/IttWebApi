using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace web_api
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Registration and mapping of the different calls.  Here is where Controller and method map to route or url  
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            /* config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
             */

            string versionConstraint = @"\d+.\d{2}";

            config.Routes.MapHttpRoute(
                name: "ApiItt",
                routeTemplate: "webapi/itt",
                defaults: new { controller = "Itt", action = "getAppStatus" }
            );

            config.Routes.MapHttpRoute(
                name: "IttStatusApi",
                routeTemplate: "webapi/{version}/ittstatus",
                defaults: new { controller = "IttStatus", action = "apiStatus" },
                constraints: new { version = versionConstraint }
            );

            config.Routes.MapHttpRoute(
                name: "IttRegisterUser",
                routeTemplate: "webapi/{version}/register/{user}",
                defaults: new { controller = "IttStatus", action = "registerUser" },
                constraints: new { version = versionConstraint }
            );

            config.Routes.MapHttpRoute(
                name: "IttPostMessage",
                routeTemplate: "webapi/{version}/postmessage",
                defaults: new { controller = "IttStatus", action = "postMessage" },
                constraints: new { version = versionConstraint }
            );
        }
    }
}

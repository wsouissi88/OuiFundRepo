using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Batch;

namespace OuiFund.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Web API Batching
            // Configuration et services API Web
            var batchHandler = new DefaultHttpBatchHandler(GlobalConfiguration.DefaultServer)
            {
                ExecutionOrder = BatchExecutionOrder.NonSequential
            };
            config.Routes.MapHttpBatchRoute(
                routeName: "WebApiBatch",
                routeTemplate: "api/batch",
                batchHandler:batchHandler);
            #endregion

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace cri.Api.Versioning
{
    public sealed class RouteVersionedControllerSelector : VersionedControllerSelector
    {
        private const string VersionKey = "version";

        /// <summary>
        ///   Initializes a new instance of the <see cref="RouteVersionedControllerSelector" /> class.
        /// </summary>
        /// <param name="configuration"> The configuration. </param>
        public RouteVersionedControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        protected override ControllerIdentification GetControllerIdentificationFromRequest(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                return default(ControllerIdentification);
            }

            // Look up controller in route data
            string controllerName = this.GetControllerNameFromRequest(request);

            // Also try the version if possible
            object apiVersionObj;
            string apiVersion = null;
            //string version;
            //if (routeData.Values.TryGetValue(VersionKey, out apiVersionObj) &&
            //    Int32.TryParse(apiVersionObj.ToString(), out version))
            //{
            //    apiVersion = version;
            //}

            if (routeData.Values.TryGetValue(VersionKey, out apiVersionObj) && !string.IsNullOrWhiteSpace(apiVersionObj.ToString()))
            {
                apiVersion = apiVersionObj.ToString().Replace(".", "_");
            }

            return new ControllerIdentification(controllerName, apiVersion);
        }
    }
}

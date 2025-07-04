// System includes.
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;

// NuGet includes.
using NuGet.Server;
using NuGet.Server.Infrastructure;
using NuGet.Server.V2;

/// <summary>
/// Sets this file as the primary startup file for the server.
/// </summary>
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PackageServer.App_Start.NuGetODataConfig), "Start")]

namespace PackageServer.App_Start 
{
    public static class NuGetODataConfig 
    {
        /// <summary>
        /// Start everything!
        /// </summary>
        public static void Start() 
        {
            ServiceResolver.SetServiceResolver(new DefaultServiceResolver());

            var config = GlobalConfiguration.Configuration;

            NuGetV2WebApiEnabler.UseNuGetV2WebApiFeed(
                config,
                "NuGetDefault",
                "nuget",
                "PackagesOData",
                enableLegacyPushRoute: true);

            config.Services.Replace(typeof(IExceptionLogger), new TraceExceptionLogger());

            // Trace.Listeners.Add(new TextWriterTraceListener(HostingEnvironment.MapPath("~/NuGet.Server.log")));
            // Trace.AutoFlush = true;

            // Map those routes!
            config.Routes.MapHttpRoute(
                name: "NuGetDefault_ClearCache",
                routeTemplate: "nuget/clear-cache",
                defaults: new { controller = "PackagesOData", action = "ClearCache" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

        }
    }
}

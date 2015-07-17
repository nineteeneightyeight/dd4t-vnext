﻿using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using System;
using Microsoft.Framework.OptionsModel;

namespace DD4T.Bootstrap
{
    /// <summary>
    /// Configures the default route for DD4T and adds a constraint for favicon.ico
    /// </summary>
    public static class IApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseDD4T(this IApplicationBuilder app, Action<IRouteBuilder> configureRoutes = null)
        {
            var dd4tRoute = new RouteBuilder
            {
                DefaultHandler = new MvcRouteHandler(),
                ServiceProvider = app.ApplicationServices        
            };

            //If additional routes are configured, add them as well
            if (configureRoutes != null)
                configureRoutes.Invoke(dd4tRoute);

            //add a constraintmap for requests for favicon.ico
            //dd4tRoute.ServiceProvider.GetService<IOptions<RouteOptions>>().Options.ConstraintMap.Add("faviconIgnoreConstraint", typeof(IgnoreFaviconIcoRouteConstraint));
      
            //Always map the default route and apply the favicon ignore constaint           
            dd4tRoute.MapRoute(
                    name: "TridionPage",
                    template: "{*PageUrl:faviconIgnoreConstraint}",
                    defaults: new { controller = "Page", action = "Page" } // action = "PageAsync" }
                    //defaults: new { controller = "ComponentPresentation", action = "CP" }                   
                    );
                        

            return app.UseMiddleware<DD4TMiddleWare>(dd4tRoute.Build());
        }
    }

    

    
}
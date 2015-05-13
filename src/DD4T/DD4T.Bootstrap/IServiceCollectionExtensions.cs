﻿using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.Providers.Mock;
using DD4T.ContentModel.Factories;
using DD4T.Factories;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.Utils.Defaults;
using DD4T.Utils;


namespace DD4T.Bootstrap
{
    public static class IServiceCollectionExtensions
    {

        public static void AddDD4T(this IServiceCollection services)
        {
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            

            services.Configure<DD4TConfiguration>(configuration.GetSubKey("DD4TAppSettings"));
            services.AddTransient<IPageProvider, TridionPageProvider>();
            services.AddTransient<IPageFactory, PageFactory>();
            services.AddSingleton<IPublicationResolver, DefaultPublicationResolver>();
        }
    }
}

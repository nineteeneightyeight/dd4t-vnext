﻿using DD4T.ContentModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Providers;
using Newtonsoft.Json;
using Microsoft.Framework.Logging;

namespace DD4T.Factories
{
    public class PageFactory : FactoryBase, IPageFactory
    {
        private readonly IPageProvider PageProvider;
       // private readonly INewComponentPresentationProvider ComponentPresentationProvider;

        public PageFactory(IPageProvider pageProvider, ILoggerFactory loggerfactory)
            : base(pageProvider, loggerfactory)
        {
            PageProvider = pageProvider;
        }

        public async Task<IPage> GetPage(string pageUrl)
        {
            string pageContentFromBroker = await PageProvider.GetContentByUrl(pageUrl);

            if (string.IsNullOrEmpty(pageContentFromBroker))
                return null;

            //Create an IPage object from the stringcontent
            return await GetIPageObject(pageContentFromBroker);
        }

        #region Private Helpers
        public async Task<IPage> GetIPageObject(string pageStringContent)
        {
            IPage page;

            //Logger.Debug("GetIPageObject: about to deserialize and decompress", LoggingCategory.Performance);
            JsonSerializerSettings s = new JsonSerializerSettings { };
            s.Converters.Add(new FieldConverter());
            //page = await JsonConvert.DeserializeObjectAsync<Page>(pageStringContent, s);
            page = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Page>(pageStringContent, s));

            //page = ProtoBuf.Serializer.Deserialize<Page>(new MemoryStream(Convert.FromBase64String(pageStringContent)));
            //var t = ProtoBuf.Serializer.Deserialize<TempModel>(new MemoryStream(Convert.FromBase64String(pageStringContent)));

            //Logger.Debug("GetIPageObject: finished deserializing and decompressing", LoggingCategory.Performance);
            int orderOnPage = 0;
            foreach (IComponentPresentation cp in page.ComponentPresentations)
            {
                cp.OrderOnPage = orderOnPage++;
            }
            //Logger.Debug("GetIPageObject: about to load DCPs", LoggingCategory.Performance);
            //LoadComponentModelsFromComponentFactory(page);
            //Logger.Debug("GetIPageObject: finished loading DCPs", LoggingCategory.Performance);

            //Logger.Debug("<<GetIPageObject(string length {0})", LoggingCategory.Performance, Convert.ToString(pageStringContent.Length));
            return page;
        }
        #endregion

    }
}

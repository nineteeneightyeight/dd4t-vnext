﻿using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Providers.Mock
{
    public class ComponentPresentationProvider : BaseProvider, IComponentPresentationProvider
    {
        public ComponentPresentationProvider(IPublicationResolver publicationResolver, ILoggerFactory loggerfactory)
            : base(publicationResolver, loggerfactory)
        {

        }
        public async Task<string> GetComponentPresentationContent(string componentUri, string componentTemplateUri = "")
        {
            //var task = new Task<string>(() => { return "{\"component\":{\"lastPublishedDate\":\"0001-01-01T00:00:00\",\"revisionDate\":\"2014-03-12T06:51:14.803\",\"schema\":{\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-13-2\",\"title\":\"Schemas\"},\"rootElementName\":\"Content\",\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-123-8\",\"title\":\"Article\"},\"fields\":{},\"metadataFields\":{},\"componentType\":1,\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-15-2\",\"title\":\"Content\"},\"categories\":[{\"keywords\":[],\"id\":\"tcm:9-4021-512\",\"title\":\"Product Group\"}],\"version\":4,\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"owningPublication\":{\"id\":\"tcm:0-5-1\",\"title\":\"04 Dutch Content\"},\"id\":\"tcm:9-3152\",\"title\":\"Homepage teaser 2\"},\"componentTemplate\":{\"outputFormat\":\"HTML Fragment\",\"revisionDate\":\"2014-08-29T15:42:14.953\",\"folder\":{\"publicationId\":\"tcm:0-9-1\",\"id\":\"tcm:9-14-2\",\"title\":\"Component Templates\"},\"publication\":{\"id\":\"tcm:0-9-1\",\"title\":\"07 Dutch website\"},\"id\":\"tcm:9-3148-32\",\"title\":\"Article\"},\"isDynamic\":true,\"orderOnPage\":0}"; });
            var cp = "{\"Component\":{\"LastPublishedDate\":\"0001-01-01T00:00:00\",\"RevisionDate\":\"2015-04-25T15:19:17\",\"Schema\":{\"Folder\":{\"PublicationId\":\"tcm:0-3-1\",\"Id\":\"tcm:3-1072-2\",\"Title\":\"Schemas\"},\"RootElementName\":\"Product\",\"Publication\":{\"Id\":\"tcm:0-3-1\",\"Title\":\"400 Example Site\"},\"Id\":\"tcm:3-1310-8\",\"Title\":\"Product\"},\"Fields\":{\"title\":{\"Name\":\"title\",\"Value\":\"This is a Product to sell 2\",\"Values\":[\"This is a Product to sell 2\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":0,\"XPath\":\"tcm:Content/custom:Product/custom:title\",\"Keywords\":[],\"KeywordValues\":[]},\"description\":{\"Name\":\"description\",\"Value\":\"here is additional description\",\"Values\":[\"here is additional description\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":2,\"XPath\":\"tcm:Content/custom:Product/custom:description\",\"Keywords\":[],\"KeywordValues\":[]}},\"MetadataFields\":{},\"ComponentType\":1,\"Folder\":{\"PublicationId\":\"tcm:0-3-1\",\"Id\":\"tcm:3-60-2\",\"Title\":\"Homepage\"},\"Categories\":[{\"Keywords\":[],\"Id\":\"tcm:3-1074-512\",\"Title\":\"Product Audience\"}],\"Version\":5,\"Publication\":{\"Id\":\"tcm:0-3-1\",\"Title\":\"400 Example Site\"},\"OwningPublication\":{\"Id\":\"tcm:0-3-1\",\"Title\":\"400 Example Site\"},\"Id\":\"tcm:3-1313\",\"Title\":\"A Product\"},\"ComponentTemplate\":{\"OutputFormat\":\"HTML Fragment\",\"RevisionDate\":\"2015-04-24T15:09:14.857\",\"MetadataFields\":{\"controller\":{\"Name\":\"controller\",\"Value\":\"Product:Product\",\"Values\":[\"Product:Product\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":0,\"Keywords\":[],\"KeywordValues\":[]},\"action\":{\"Name\":\"action\",\"Value\":\"Hallo\",\"Values\":[\"Hallo\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":0,\"Keywords\":[],\"KeywordValues\":[]},\"view\":{\"Name\":\"view\",\"Value\":\"Product:ProductOverviewDynamic\",\"Values\":[\"Product:ProductOverviewDynamic\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":0,\"Keywords\":[],\"KeywordValues\":[]},\"regionView\":{\"Name\":\"regionView\",\"Value\":\"3-Column\",\"Values\":[\"3-Column\"],\"NumericValues\":[],\"DateTimeValues\":[],\"LinkedComponentValues\":[],\"FieldType\":0,\"Keywords\":[],\"KeywordValues\":[]}},\"Folder\":{\"PublicationId\":\"tcm:0-2-1\",\"Id\":\"tcm:2-1073-2\",\"Title\":\"Templates\"},\"Publication\":{\"Id\":\"tcm:0-2-1\",\"Title\":\"100 Master\"},\"OwningPublication\":{\"Id\":\"tcm:0-2-1\",\"Title\":\"100 Master\"},\"Id\":\"tcm:2-1314-32-v0\",\"Title\":\"Product Dynamic [3-Column]\"},\"IsDynamic\":true,\"OrderOnPage\":0}"; 
            var task = new Task<string>(() => { return cp; });
            task.Start();
            return await task;
        }
    }
}

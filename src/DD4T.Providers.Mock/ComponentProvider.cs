﻿using DD4T.ContentModel.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD4T.ContentModel.Querying;

namespace DD4T.Providers.Mock
{
    public class ComponentProvider : IComponentProvider
    {
        public int PublicationId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<string> FindComponents(IQuery queryParameters)
        {
            throw new NotImplementedException();
        }

        public string GetContent(string uri, string templateUri = "")
        {
            throw new NotImplementedException();
        }

        public List<string> GetContentMultiple(string[] componentUris)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastPublishedDate(string uri)
        {
            throw new NotImplementedException();
        }
    }
}

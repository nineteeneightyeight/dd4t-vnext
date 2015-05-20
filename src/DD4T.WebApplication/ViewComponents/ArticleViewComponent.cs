﻿using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Factories;
using DD4T.WebApplication.Models;
using DVM4T.Contracts;
using DVM4T.Core;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DD4T.WebApplication.ViewComponents
{
    [ViewComponent(Name = "Article")]
    public class ArticleViewComponent : ViewComponent
    {

        public IComponentPresentationFactory ComponentPresentationFactory { get; private set; }
        private readonly ILogger Logger;

        public ArticleViewComponent(IComponentPresentationFactory componentPresentationFactory, ILoggerFactory loggerfactory)
        {
            Logger = loggerfactory.CreateLogger<ArticleViewComponent>();

            if (componentPresentationFactory == null)
                throw new ArgumentNullException("componentPresentationFactory");

            Logger.LogDebug("TridionPageController", componentPresentationFactory);

            ComponentPresentationFactory = componentPresentationFactory;
        }

        public IViewComponentResult Invoke(Article article)
        {
            //IComponentPresentationData cpDataObject = new DVM4T.DD4T.ComponentPresentation(cp);
            //ViewModelDefaults.Factory.LoadViewModels(Assembly.GetAssembly(this.GetType()));
            //var model = ViewModelDefaults.Factory.BuildViewModel(cpDataObject);

             
            return View("Article", article);
        }

        //public async Task<IViewComponentResult> InvokeAsync(Article article)
        //{
        //    var model = await GetModelAsync(cp);
        //    return View(model.GetType().Name, model);
        //}

        //private Task<object> GetModelAsync(IComponentPresentation cp)
        //{
        //    return Task.FromResult(GetModel(cp));

        //}
        //private object GetModel(IComponentPresentation cp)
        //{
        //    IComponentPresentationData cpDataObject = new DVM4T.DD4T.ComponentPresentation(cp);
        //    ViewModelDefaults.Factory.LoadViewModels(Assembly.GetAssembly(this.GetType()));
        //    var model = ViewModelDefaults.Factory.BuildViewModel(cpDataObject);
        //    return model;
        //}

    }
}

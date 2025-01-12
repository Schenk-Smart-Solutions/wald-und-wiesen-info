﻿using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Logging;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
{
    public class HomePageController : BasePageController
    {
        protected readonly IMutoboContentService ContentService;


        public HomePageController(IMutoboContentService contentService)
        {
            Logger.Info<HomePageController>("HomePageController initialized");
            ContentService = contentService;
        }


        public override ActionResult Index(ContentModel model)
        {

            var basepage = new BasePage(model.Content);



            return base.Index<HomePage>(new HomePage(model.Content)
            {
                Modules = ContentService.GetContent(model.Content, DocumentTypes.HomePage.Fields.Modules)
            });
        }
    }
}
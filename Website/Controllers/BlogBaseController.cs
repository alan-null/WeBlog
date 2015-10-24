﻿using System;
using System.ComponentModel;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Modules.WeBlog.Items.WeBlog;
using Sitecore.Modules.WeBlog.layouts;
using Sitecore.Modules.WeBlog.Managers;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Modules.WeBlog.Controllers
{
    public class BlogBaseController : Controller
    {
        private BlogHomeItem _currentBlog;
        private EntryItem _currentEntry;
        private Item _datasource;
        public RenderingParameterHelper RenderingParameterHelper { get; set; }

        [TypeConverter(typeof(Converters.ExtendedBooleanConverter))]
        public bool VaryByBlog { get; set; }

        public BlogHomeItem CurrentBlog
        {
            get { return _currentBlog ?? (_currentBlog = ManagerFactory.BlogManagerInstance.GetCurrentBlog()); }
        }

        public EntryItem CurrentEntry
        {
            get { return _currentEntry ?? (_currentEntry = new EntryItem(DataSourceItem)); }
        }

        public Item DataSourceItem
        {
            get
            {
                if (_datasource == null)
                {
                    var renderingContext = RenderingContext.CurrentOrNull;
                    if (renderingContext != null)
                    {
                        if (String.IsNullOrEmpty(renderingContext.Rendering.DataSource))
                        {
                            _datasource = renderingContext.ContextItem;
                        }
                        else
                        {
                            _datasource = Context.Database.GetItem(renderingContext.Rendering.DataSource);
                        }
                    }

                }
                return _datasource;
            }
        }

        public BlogBaseController()
        {
            RenderingParameterHelper = new RenderingParameterHelper(this, true);
        }
    }
}
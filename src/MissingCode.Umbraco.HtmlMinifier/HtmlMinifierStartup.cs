using System.Web.Mvc;
using Umbraco.Core;
using WebMarkupMin.AspNet4.Common;
using WebMarkupMin.AspNet4.Mvc;
using WebMarkupMin.Core;

namespace MissingCode.Umbraco.HtmlMinifier
{
    public class HtmlMinifierStartup : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var htmlMinificationSettings = HtmlMinificationManager.Current.MinificationSettings;

            if (!PluginSettings.RemoveAttributeQuotes)
            {
                htmlMinificationSettings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.KeepQuotes;
            }
            htmlMinificationSettings.RemoveOptionalEndTags = PluginSettings.RemoveOptionalEndTags;

            var filters = GlobalFilters.Filters;
            //filters.Add(new CompressContentAttribute());
            filters.Add(new MinifyHtmlAttribute());
            //filters.Add(new MinifyXmlAttribute());

            base.ApplicationStarting(umbracoApplication, applicationContext);
        }

        
    }
}

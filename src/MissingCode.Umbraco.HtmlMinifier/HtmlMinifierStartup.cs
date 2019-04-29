using Umbraco.Core;
using Umbraco.Core.Composing;
using WebMarkupMin.AspNet4.Common;
using WebMarkupMin.AspNet4.Mvc;
using WebMarkupMin.Core;
using System.Web.Mvc;

namespace MissingCode.Umbraco.HtmlMinifier
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MyComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<HtmlMinifierComponent>();
        }
    }
    public class HtmlMinifierComponent : IComponent
    {
        public void Initialize()
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
        }

        public void Terminate()
        {
            
        }       

        
    }
}

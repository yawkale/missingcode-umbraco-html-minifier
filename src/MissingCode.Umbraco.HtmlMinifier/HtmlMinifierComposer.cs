using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using WebMarkupMin.AspNetCore5;
using WebMarkupMin.Core;

namespace MissingCode.Umbraco.HtmlMinifier
{
    public class StartupFilter : IStartupFilter
	{
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
		{
			app.UseWebMarkupMin();
			next(app);
		};
	}

	public class HtmlMinifierComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
			builder.Services.AddTransient<IStartupFilter, StartupFilter>();

			var htmlMinifierOptions = new HtmlMinifierPluginSettings();
			builder.Config.GetSection(HtmlMinifierPluginSettings.ConfigurationName).Bind(htmlMinifierOptions);


			builder.Services.AddWebMarkupMin(options =>
			{
				options.AllowMinificationInDevelopmentEnvironment = htmlMinifierOptions.AllowMinificationInDevelopmentEnvironment;
				options.AllowCompressionInDevelopmentEnvironment = htmlMinifierOptions.AllowMinificationInDevelopmentEnvironment;
			})
				.AddHtmlMinification(options =>
				{
					HtmlMinificationSettings settings = options.MinificationSettings;
					settings.RemoveRedundantAttributes = true;
					settings.RemoveHttpProtocolFromAttributes = true;
					settings.RemoveHttpsProtocolFromAttributes = true;

					if (!htmlMinifierOptions.RemoveAttributeQuotes)
                    {
						settings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.KeepQuotes;
					}					
					settings.RemoveOptionalEndTags = htmlMinifierOptions.RemoveOptionalEndTags;
				});


			

		}
    }
}

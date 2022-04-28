using System.ComponentModel;

namespace MissingCode.Umbraco.HtmlMinifier
{
    public class HtmlMinifierPluginSettings
    {

        public const string ConfigurationName = "HtmlMinifier";

        [DefaultValue(false)]
        public bool RemoveAttributeQuotes { get; set; } = false;

        [DefaultValue(false)]
        public bool RemoveOptionalEndTags { get; set; } = false;

        [DefaultValue(false)]
        public bool AllowMinificationInDevelopmentEnvironment { get; set; } = false;

        

    }
}

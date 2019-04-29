using System;
using System.Configuration;
using System.Globalization;

namespace MissingCode.Umbraco.HtmlMinifier
{
    public static class PluginSettings
    {

        private static T GetProperty<T>(string key, T defaultValue)
        {

            var configuration = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configuration))
                return defaultValue;

            return (T)Convert.ChangeType(configuration, typeof(T), CultureInfo.InvariantCulture);

        }

        public static bool RemoveAttributeQuotes => GetProperty<bool>("RemoveAttributeQuotes", false);
        public static bool RemoveOptionalEndTags => GetProperty<bool>("RemoveOptionalEndTags", false);

    }
}

using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ReactSPA6_ALL.Localization
{
    public static class ReactSPA6_ALLLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ReactSPA6_ALLConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ReactSPA6_ALLLocalizationConfigurer).GetAssembly(),
                        "ReactSPA6_ALL.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

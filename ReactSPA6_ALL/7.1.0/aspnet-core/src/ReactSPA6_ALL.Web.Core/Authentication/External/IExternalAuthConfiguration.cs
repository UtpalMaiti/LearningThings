using System.Collections.Generic;

namespace ReactSPA6_ALL.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}

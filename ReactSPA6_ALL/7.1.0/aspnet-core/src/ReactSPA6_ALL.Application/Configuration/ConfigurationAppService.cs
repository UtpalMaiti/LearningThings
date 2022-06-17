using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ReactSPA6_ALL.Configuration.Dto;

namespace ReactSPA6_ALL.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ReactSPA6_ALLAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

using System.Threading.Tasks;
using ReactSPA6_ALL.Configuration.Dto;

namespace ReactSPA6_ALL.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using ReactSPA6_ALL.Authorization.Accounts.Dto;

namespace ReactSPA6_ALL.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

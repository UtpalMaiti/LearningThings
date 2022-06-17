using System.Threading.Tasks;
using Abp.Application.Services;
using ReactSPA6_ALL.Sessions.Dto;

namespace ReactSPA6_ALL.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

using Abp.Application.Services;
using ReactSPA6_ALL.MultiTenancy.Dto;

namespace ReactSPA6_ALL.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ReactSPA6_ALL.MultiTenancy;

namespace ReactSPA6_ALL.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}

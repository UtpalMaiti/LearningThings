using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ReactSPA6_ALL.Controllers
{
    public abstract class ReactSPA6_ALLControllerBase: AbpController
    {
        protected ReactSPA6_ALLControllerBase()
        {
            LocalizationSourceName = ReactSPA6_ALLConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

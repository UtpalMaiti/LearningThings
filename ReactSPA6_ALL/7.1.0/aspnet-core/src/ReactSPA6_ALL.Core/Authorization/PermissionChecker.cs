using Abp.Authorization;
using ReactSPA6_ALL.Authorization.Roles;
using ReactSPA6_ALL.Authorization.Users;

namespace ReactSPA6_ALL.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

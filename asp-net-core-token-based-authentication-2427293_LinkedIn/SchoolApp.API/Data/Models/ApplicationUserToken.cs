using Microsoft.AspNetCore.Identity;

namespace SchoolApp.API.Data.Models
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public override string UserId { get => base.UserId; set => base.UserId = value; }
        public override string LoginProvider { get => base.LoginProvider; set => base.LoginProvider = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override string Value { get => base.Value; set => base.Value = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using Microsoft.AspNetCore.Identity;

using System.Security.Claims;

namespace SchoolApp.API.Data.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string UserId { get => base.UserId; set => base.UserId = value; }
        public override string ClaimType { get => base.ClaimType; set => base.ClaimType = value; }
        public override string ClaimValue { get => base.ClaimValue; set => base.ClaimValue = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void InitializeFromClaim(Claim claim)
        {
            base.InitializeFromClaim(claim);
        }

        public override Claim ToClaim()
        {
            return base.ToClaim();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

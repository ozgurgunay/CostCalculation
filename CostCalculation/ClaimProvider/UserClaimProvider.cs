using CostCalculation.Data;
using Microsoft.AspNetCore.Identity;

namespace CostCalculation.ClaimProvider
{
    public class UserClaimProvider
    {
        private readonly UserManager<AppUser> _userManager;

        public UserClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
    }
}

using CostCalculation.Data;
using Microsoft.AspNetCore.Identity;

namespace CostCalculation.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUserName", Description = "Şifre kullanıcı adını içeremez!" });
            }

            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordStart1234", Description = "Şifre '1234' ile başlayamaz!" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }        
    }
}

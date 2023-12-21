using CostCalculation.Data;
using CostCalculation.Enums;
using CostCalculation.Services.IServices;
using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace CostCalculation.Services
{
    public class MemberService : IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFileProvider _fileProvider;
        public MemberService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _fileProvider = fileProvider;
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> ChangePasswordAsync(string userName, string oldPassword, string newPassword)
        {
            var currentUser = (await _userManager.FindByNameAsync(userName));
            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser, oldPassword, newPassword);
            if (!resultChangePassword.Succeeded)
            {
                return (false, resultChangePassword.Errors);
            }
            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser, newPassword, true, false);

            return (true, null);
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);
            return await _userManager.CheckPasswordAsync(currentUser, password);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public SelectList GetGenderSelectList()
        {
            return new SelectList(Enum.GetNames(typeof(EGender)));
        }
        public async Task<UserViewModel> GetUserViewModelByUserName(string userName)
        {
            var currentUser = (await _userManager.FindByNameAsync(userName)!);

            return new ViewModels.UserViewModel
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
                PictureUrl = currentUser.Picture
            };
        }
        public async Task<UserEditViewModel> GetUserEditViewModelAsync(string userName)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);
            return new UserEditViewModel()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
                BirthDate = currentUser.BirthDate,
                Gender = currentUser.Gender
            };
        }
        public async Task<(bool, IEnumerable<IdentityError>?)> EditUserAsync(UserEditViewModel model, string userName)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);
            currentUser.UserName = model.UserName;
            currentUser.Email = model.Email;
            currentUser.PhoneNumber = model.PhoneNumber;
            currentUser.BirthDate = model.BirthDate;
            currentUser.Gender = model.Gender;

            if (model.Picture != null && model.Picture.Length > 0)
            {
                var wwwroot = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwroot.First(x => x.Name == "userPictures").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await model.Picture.CopyToAsync(stream);
                currentUser.Picture = randomFileName;
            }
            var updateToUserResult = await _userManager.UpdateAsync(currentUser);

            if (!updateToUserResult.Succeeded)
            {
                return (false, updateToUserResult.Errors);
            }
            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            var claims = new List<Claim>();
            if (claims.Any())
            {
                await _signInManager.SignInWithClaimsAsync(currentUser, true, claims.ToArray());
            }
            else
            {
                // If there are no claims, you can use the regular SignInAsync
                await _signInManager.SignInAsync(currentUser, true);
            }
            return (true, null);
        }
    }
}

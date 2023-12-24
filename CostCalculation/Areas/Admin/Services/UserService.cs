using CostCalculation.Areas.Admin.DTOs;
using CostCalculation.Areas.Admin.Services.IServices;
using CostCalculation.Areas.Admin.ViewModels;
using CostCalculation.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

namespace CostCalculation.Areas.Admin.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserViewModel> GetUserByIdAsync(string userId)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);
            return new ViewModels.UserViewModel()
            {
                Id = currentUser.Id,
                Name = currentUser.UserName,
                Email = currentUser.Email,
                IsApproved = currentUser.IsApproved
            };
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> UpdateUserApproved(UserApprovedDTO userApprovedDTO, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return (false, new List<IdentityError> { new IdentityError { Description = "Kullanıcı bulunamadı." } });
            }

            user.IsApproved = userApprovedDTO.IsApproved;

            var result = await _userManager.UpdateAsync(user);

            return (result.Succeeded, result.Errors);
        }
    }
}

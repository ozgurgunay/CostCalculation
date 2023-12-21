using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostCalculation.Services.IServices
{
    public interface IMemberService
    {
        Task Logout();
        Task<bool> CheckPasswordAsync(string userName, string password);
        Task<(bool, IEnumerable<IdentityError>?)> ChangePasswordAsync(string userName, string oldPassword, string newPassword);
        Task<UserEditViewModel> GetUserEditViewModelAsync(string userName);
        Task<(bool, IEnumerable<IdentityError>?)> EditUserAsync(UserEditViewModel model, string userName);
        SelectList GetGenderSelectList();
        Task<UserViewModel> GetUserViewModelByUserName(string userName);
    }
}

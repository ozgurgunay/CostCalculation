using CostCalculation.Areas.Admin.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CostCalculation.Areas.Admin.Services.IServices
{
    public interface IUserService
    {
        Task<ViewModels.UserViewModel> GetUserByIdAsync(string userId);
        Task<(bool, IEnumerable<IdentityError>?)> UpdateUserApproved(UserApprovedDTO userApprovedDTO, string userName);
    }
}

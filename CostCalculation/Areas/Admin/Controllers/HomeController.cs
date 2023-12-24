using CostCalculation.Areas.Admin.DTOs;
using CostCalculation.Areas.Admin.Services.IServices;
using CostCalculation.Areas.Admin.ViewModels;
using CostCalculation.Data;
using CostCalculation.Extensions;
using CostCalculation.Services;
using CostCalculation.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CostCalculation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        #region Variables       
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        #endregion
        #region Constructor
        public HomeController(UserManager<AppUser> userManager, IUserService userService, IEmailService emailService)
        {
            _userManager = userManager;
            _userService = userService;
            _emailService = emailService;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();

            var userViewModelList = userList.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.UserName,
                IsApproved = x.IsApproved
            }).ToList();

            return View(userViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateApprovalStatus([FromBody] UserApprovedDTO userApprovedDTO)
        {
            var user = await _userService.GetUserByIdAsync(userApprovedDTO.UserId!);
            if (user != null)
            {
                var (isSuccess, errors) = await _userService.UpdateUserApproved(userApprovedDTO, user.Name!);
                if (isSuccess)
                {
                    await _emailService.SendActivatedInfoEmail(user.Email!, userApprovedDTO.IsApproved);
                    return Ok(isSuccess);
                }
                else
                {
                    ModelState.AddModelErrorList(errors!);
                }
            }
            return NotFound();
        }
    }
}

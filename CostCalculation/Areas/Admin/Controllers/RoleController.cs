using CostCalculation.Areas.Admin.ViewModels;
using CostCalculation.Data;
using CostCalculation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CostCalculation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name!
            }).ToListAsync();
            return View(roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = model.Name });
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }
            TempData["SuccessMessage"] = "Role created.";
            return RedirectToAction(nameof(RoleController.Index));
        }
        public async Task<IActionResult> UpdateRole(string Id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(Id);
            if (roleToUpdate == null)
            {
                throw new Exception("Bu rolü bulamadık!");
            }

            return View(new UpdateRoleViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate.Name });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(model.Id);
            if (roleToUpdate == null)
            {
                throw new Exception("Bu rol bulunamadı!");
            }

            roleToUpdate.Name = model.Name;

            await _roleManager.UpdateAsync(roleToUpdate);

            ViewData["SuccessMessage"] = "Rol güncellendi.";

            return View();
        }
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(Id);
            if (roleToDelete == null)
            {
                throw new Exception("Bu rol bulunamadı!");
            }
            var result = await _roleManager.DeleteAsync(roleToDelete);
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
            }

            TempData["SuccessMessage"] = "Rol silindi.";

            return RedirectToAction(nameof(RoleController.Index));
        }
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = await _userManager.FindByIdAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(currentUser);
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            ViewBag.userId = id;

            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel() { Id = role.Id, Name = role.Name };
                if (userRoles.Contains(role.Name!))
                {
                    assignRoleToUserViewModel.Exist = true;
                }
                roleViewModelList.Add(assignRoleToUserViewModel);
            }

            return View(roleViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userId, List<AssignRoleToUserViewModel> modelList)
        {
            var assignRoleToUser = await _userManager.FindByIdAsync(userId);

            foreach (var role in modelList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(assignRoleToUser, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(assignRoleToUser, role.Name);
                }
            }

            return RedirectToAction(nameof(HomeController.UserList), "Home");
        }

    }
}

using CostCalculation.Data;
using CostCalculation.Enums;
using CostCalculation.Extensions;
using CostCalculation.Services.IServices;
using CostCalculation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostCalculation.Controllers
{
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMemberService _memberService;
        private string userName => User.Identity!.Name!;

        public MemberController(IMemberService memberService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _memberService = memberService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _memberService.GetUserViewModelByUserName(userName));
        }
        public async Task Logout()
        {
            await _memberService.Logout();
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!await _memberService.CheckPasswordAsync(userName, model.PasswordOld))
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz hatalı!");
                return View();
            }
            var (isSuccess, errors) = await _memberService.ChangePasswordAsync(userName, model.PasswordOld, model.PasswordNew);
            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!);
                return View();
            }
            TempData["SuccessMessage"] = "Şifre başarılı bir şekilde değiştirildi.";

            return View();
        }
        public async Task<IActionResult> UserEdit()
        {
            ViewBag.GenderList = new SelectList(Enum.GetNames(typeof(EGender)));
            return View(await _memberService.GetUserEditViewModelAsync(userName));
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var (isSuccess, errors) = await _memberService.EditUserAsync(model, userName);
            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!);
                return View();
            }
            TempData["SuccessMessage"] = "Kullanıcı bilgileri başarılı bir şekilde güncellendi.";
            return View(await _memberService.GetUserEditViewModelAsync(userName));
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            string message = string.Empty;
            message = "Bu sayfayı görmeye yetkiniz yok! Sorry, not sorry dudeee.";
            ViewBag.message = message;
            return View();
        }

    }
}

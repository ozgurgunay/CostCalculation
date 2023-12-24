using CostCalculation.Data;
using CostCalculation.Extensions;
using CostCalculation.Services.IServices;
using CostCalculation.ViewModels;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CostCalculation.Controllers
{    
    public class HomeController : Controller
    {
        #region Variables
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEmailService _emailService;
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<HomeController> _logger;
        #endregion

        #region Constructor
        public HomeController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, ILogger<HomeController> logger, ICurrencyService currencyService)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _logger = logger;
            _currencyService = currencyService;
        }

        #endregion

        public IActionResult Index()
        {
            //hangfire for get currency every 55minutes
            RecurringJob.AddOrUpdate("exchange-rate-job", () => _currencyService.StoreEuroCurrencyData(), "*/55 * * * *");
            
            return View();
        }
        public IActionResult SignUp()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                IsApproved = false
            }, request.PasswordConfirm);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                return View();
            }

            TempData["SuccessMessage"] = "Kayıt başarılı. Hesabınıza giriş yapabilmek için aktivasyon mailinin gelmesini bekleyiniz.";
            return RedirectToAction(nameof(HomeController.SignUp));
        }
        public IActionResult SignIn()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //In this method, the returnUrl is for the user to give this link to return to the page they left off after logging in, if they want to become a member of a page they are trying to access, and be directed directly to the last page they viewed. It doesn't have to be.
            returnUrl ??= Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "E-Mail veya şifreniz yanlış!");
                return View();
            }
            if (!hasUser.IsApproved)
            {
                ModelState.AddModelError(string.Empty, "Hesabınız yöneticiniz tarafından henüz onaylanmamıştır!");
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, false);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Hatalı girişler yaptınız 3 dakika boyunca giriş yapamazsınız." });
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { "E-Mail veya şifreniz yanlış!", $"Hatalı giriş = {await _userManager.GetAccessFailedCountAsync(hasUser)}" });
                return View();
            }
            var claims = new List<Claim>();
            if (claims.Any())
            {
                await _signInManager.SignInWithClaimsAsync(hasUser, request.RememberMe, claims.ToArray());
            }
            else
            {
                // If there are no claims, you can use the regular SignInAsync
                await _signInManager.SignInAsync(hasUser, request.RememberMe);
            }     

            return Redirect(returnUrl!);
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            //link
            //https://localhost:7013?userId=132&token=hvsydhba
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Bu mail adresinde kullanıcı bulunamadı.");
                return View();
            }
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userId = hasUser.Id, Token = passwordResetToken }, HttpContext.Request.Scheme);
            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email);
            TempData["SuccessMessage"] = "Şifre sıfırlama linki mail adresinize gönderildi.";

            return RedirectToAction(nameof(ForgetPassword));
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if (userId == null || token == null)
            {
                throw new Exception("Şifre hatası!");
            }
            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View();
            }
            var result = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);
            if (result.Succeeded)
            {
                await _emailService.SendPasswordUpdatedEmail(hasUser.Email);
                TempData["SuccessMessage"] = "Şifreniz sıfırlanmıştır.";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            }

            return View();
        }
        public async Task<IActionResult> GetCurrencyData()
        {
            var currencyInfo = await _currencyService.GetCurrencyData();
            if(currencyInfo == null)
            {
                return NotFound();
            }
            return Ok(currencyInfo);
        }

    }
}

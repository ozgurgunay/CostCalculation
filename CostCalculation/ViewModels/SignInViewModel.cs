using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class SignInViewModel
    {     
        public SignInViewModel()
        {

        }
        //alt + enter shortcut for create Constructor.
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz!")]
        [EmailAddress(ErrorMessage = "Password")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; } = null!;

        [Display(Name = "Hatırlanmak istiyorum xd!")]
        public bool RememberMe { get; set; }
    }
}

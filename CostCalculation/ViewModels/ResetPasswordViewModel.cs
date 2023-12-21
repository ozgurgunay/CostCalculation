using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        [Display(Name = "Yeni Şifre :")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler aynı değil!")]
        [Required(ErrorMessage = "Şifre Onay alanı boş bırakılamaz!")]
        [Display(Name = "Yeni Şifre Onay :")]
        public string PasswordConfirm { get; set; } = null!;
    }
}

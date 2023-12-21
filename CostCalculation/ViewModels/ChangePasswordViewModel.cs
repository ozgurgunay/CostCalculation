using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Eski şifre alanı boş bırakılamaz!")]
        [Display(Name = " Eski Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalı.")]
        public string PasswordOld { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni şifre alanı boş bırakılamaz!")]
        [Display(Name = " Yeni Şifre :")]
        [MinLength(6, ErrorMessage = "Yeni şifreniz en az 6 karakter olmalı.")]
        public string? PasswordNew { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni şifre onay alanı boş bırakılamaz!")]
        [Display(Name = "Yeni Şifre Onay :")]
        [MinLength(6, ErrorMessage = "Yeni şifreniz en az 6 karakter olmalı.")]
        public string? PasswordNewConfirm { get; set; } = null!;
    }
}

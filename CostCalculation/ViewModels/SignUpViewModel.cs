using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {

        }
        public SignUpViewModel(string userName, string email, string password, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Lütfen e-mail formatını kontrol ediniz!")]
        [Required(ErrorMessage = "E-Mail boş bırakılamaz!")]
        [Display(Name = "E-Mail :")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz!")]
        [Display(Name = "Telefon :")]
        public string PhoneNumber { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır!")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreniz aynı değil!")]
        [Required(ErrorMessage = "Şifre Onayı boş bırakılamaz!")]
        [Display(Name = "Şifre Onayı :")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır!")]
        public string PasswordConfirm { get; set; } = null!;
    }
}

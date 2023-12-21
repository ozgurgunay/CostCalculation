using CostCalculation.Enums;
using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı bilgisi boş bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "E-mail bilgisini kontrol ediniz!")]
        [Required(ErrorMessage = "E-Mail bilgisi boş bırakılamaz!")]
        [Display(Name = "E-Mail :")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Telefon bilgisi boş bırakılamaz!")]
        [Display(Name = "Telefon :")]
        public string PhoneNumber { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi :")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Profil Fotoğrafı :")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Cinsiyet :")]
        public EGender? Gender { get; set; }
    }
}

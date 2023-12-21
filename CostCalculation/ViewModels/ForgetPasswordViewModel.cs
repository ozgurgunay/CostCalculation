using System.ComponentModel.DataAnnotations;

namespace CostCalculation.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Lütfen E-mail'inizi kontrol ediniz!")]
        [Required(ErrorMessage = "E-Mail alanı boş bırakılamaz!")]
        [Display(Name = "E-Mail :")]
        public string? Email { get; set; }
    }
}

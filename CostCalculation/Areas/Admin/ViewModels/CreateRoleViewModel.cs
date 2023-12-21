using System.ComponentModel.DataAnnotations;

namespace CostCalculation.Areas.Admin.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Rol adı boş bırakılamaz!")]
        [Display(Name = "Rol Adı :")]
        public string Name { get; set; } = null!;
    }
}

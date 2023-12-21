using System.ComponentModel.DataAnnotations;

namespace CostCalculation.Areas.Admin.ViewModels
{
    public class UpdateRoleViewModel
    {
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "Rol Adı boş bırakılamaz!")]
        [Display(Name = "Rol Adı :")]
        public string Name { get; set; } = null!;
    }
}

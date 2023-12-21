using CostCalculation.Enums;
using Microsoft.AspNetCore.Identity;

namespace CostCalculation.Data
{
    public class AppUser : IdentityUser
    {
        public string? Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public EGender? Gender { get; set; }
    }
}

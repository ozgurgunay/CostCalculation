using CostCalculation.DTOs;
using FluentValidation;

namespace CostCalculation.ValidationRules
{
    public class FreightValidation : AbstractValidator<FreightDTO>
    {
        public FreightValidation() 
        {
            RuleFor(freight => freight.FreightValue)
                .NotNull().WithMessage("Navlun değeri boş bırakılamaz.")
                .Must(value => value >= 0).WithMessage("Navlun değeri 0'dan küçük olamaz.");

            RuleFor(freight => freight.BigPalletNumber)                
                .GreaterThanOrEqualTo(0).WithMessage("Büyük Palet Sayısı 0'dan küçük olamaz.");

            RuleFor(freight => freight.SmallPalletNumber)                
                .GreaterThanOrEqualTo(0).WithMessage("Küçük Palet Sayısı 0'dan küçük olamaz.");
        }
    }
}

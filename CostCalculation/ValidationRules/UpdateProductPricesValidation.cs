using CostCalculation.DTOs;
using CostCalculation.Entities;
using FluentValidation;

namespace CostCalculation.ValidationRules
{
    public class UpdateProductPricesValidation : AbstractValidator<UpdateProductPricesDTO>
    {
        public UpdateProductPricesValidation()
        {
            RuleFor(product => product.Price)
                .NotNull().WithMessage("Ücret boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Ücret 0'dan küçük olamaz.");

            RuleFor(product => product.OutRate)
                    .NotNull().WithMessage("Çıkma Oranı boş bırakılamaz.")
                    .GreaterThanOrEqualTo(0).WithMessage("Çıkma Oranı 0'dan küçük olamaz.");
        }
    }
}

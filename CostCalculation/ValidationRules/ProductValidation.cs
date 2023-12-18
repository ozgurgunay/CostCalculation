using CostCalculation.DTOs;
using CostCalculation.Entities;
using FluentValidation;

namespace CostCalculation.ValidationRules
{
    public class ProductValidation : AbstractValidator<ProductDTO>
    {
        public ProductValidation() 
        {
            RuleFor(product => product.ProductName)
            .NotEmpty().WithMessage("Ürün Adı boş bırakılamaz.");

            RuleFor(product => product.ProductDescription)
                .NotEmpty().WithMessage("Ürün Açıklaması boş bırakılamaz.");

            RuleFor(product => product.BoxNetKg)
                .NotNull().WithMessage("Kasa net ağırlığı boş bırakılamaz.")
                .Must(value => value >= 0).WithMessage("Kasa Net Ağırlık 0'dan küçük olamaz.");

            RuleFor(product => product.BoxBrossKg)
                .NotNull().WithMessage("Kasa Brüt Kg boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Kasa Brüt Kg 0'dan küçük olamaz.");

            RuleFor(product => product.PalletBoxCount)
                .NotNull().WithMessage("Palet Kutu Sayısı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Palet Kutu Sayısı 0'dan küçük olamaz.");

            RuleFor(product => product.Pallet)
                .NotNull().WithMessage("Palet boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Palet 0'dan küçük olamaz.");

            RuleFor(product => product.BagGr)
                .NotNull().WithMessage("Kasa Ağırlığı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Kasa Ağırlığı 0'dan küçük olamaz.");

            RuleFor(product => product.Price)
                .NotNull().WithMessage("Ücret boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Ücret 0'dan küçük olamaz.");

            RuleFor(product => product.OutRate)
                .NotNull().WithMessage("Çıkma Oranı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Çıkma Oranı 0'dan küçük olamaz.");

            RuleFor(product => product.LaborCost)
                .NotNull().WithMessage("İşçi Maliyeti boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("İşçi Maliyeti 0'dan küçük olamaz.");
        }
    }
}

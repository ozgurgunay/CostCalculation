namespace CostCalculation.ViewModels
{
    public class ProductResultViewModel
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; } = null!;
    }
}

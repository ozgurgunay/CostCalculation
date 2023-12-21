namespace CostCalculation.ViewModels
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; } = null!;
    }
}

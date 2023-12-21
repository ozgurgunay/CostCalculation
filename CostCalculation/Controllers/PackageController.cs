using Microsoft.AspNetCore.Mvc;

namespace CostCalculation.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

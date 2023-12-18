using CostCalculation.Data;
using CostCalculation.Entities;
using CostCalculation.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Xml.Linq;

namespace CostCalculation.Controllers
{
    public class HomeController : Controller
    {
        #region Variables
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region Constructor
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }


    }
}

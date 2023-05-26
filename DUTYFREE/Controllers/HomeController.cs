using DUTYFREE.Models;
using DUTYFREE.Models.Products;
using DUTYFREE.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DUTYFREE.Controllers
{
    public class HomeController : Controller
    {
        public static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 30 , ProductID = 0, Quantity = 6, ImageUrl = "/Images/Pepsi_obrazek.png", Format = "pepsi-image"},
                                                                     new Product { Name = "Cola", Price = 36, ProductID = 1, ImageUrl ="/Images/Cola_obrazek.png", Format = "cola-image" },
                                                                     new Product { Name = "Tatranka", Price = 10, ProductID = 2, ImageUrl="/Images/Tatranka_obrazek.png", Format = "tatranka-image"},
                                                                     new Product { Name = "Corny", Price = 12, ProductID = 3, ImageUrl = "/Images/Corny_obrazek.png", Format = "corny-image" }};
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ProductViewModel() { Products= _products });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
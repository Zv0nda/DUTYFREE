using DUTYFREE.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DUTYFREE.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 42 }, new Product { Name = "Cola", Price = 36} };
        public IActionResult Index()
        {
            return View();
        }
    }
}

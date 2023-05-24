using DUTYFREE.Models.Products;
using Microsoft.AspNetCore.Mvc;
using DUTYFREE.ViewModels.Products;

namespace DUTYFREE.Controllers
{
    public class ProductsController : Controller
    {
        public static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 30 , ProductID = 0, Quantity = 6, ImageUrl = "https://www.officeo.cz/galerie/1_242844/pepsi-plech-24x-0-33-l-default.jpg", Format = "pepsi-image"},
                                                                     new Product { Name = "Cola", Price = 36, ProductID = 1, ImageUrl ="https://www.officeo.cz/galerie/1_182632/coca-cola-6x-1-5-l-default.jpg", Format = "cola-image" },
                                                                     new Product { Name = "Tatranka", Price = 10, ProductID = 2, ImageUrl="https://www.officeo.cz/galerie/1_28264/horalky-sedita-arasidove-50-g-default.jpg", Format = "tatranka-image"},
                                                                     new Product { Name = "Corny", Price = 12, ProductID = 3, ImageUrl = "https://secure.ce-tescoassets.com/assets/CZ/519/4011800546519/ShotType1_540x540.jpg", Format = "corny-image" }};


        public IActionResult Administration()
        {
            var vm = new AdminViewModel();
            vm.Products = _products;
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            return RedirectToAction("Administration");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

         [HttpPost]
         public IActionResult Insert(Product newProduct)
         {
             newProduct.ProductID = _products.Max(p => p.ProductID) + 1;
             _products.Add(newProduct);

             return RedirectToAction("Administration");
         }

         [HttpGet]
         public IActionResult Delete(int id)
         {
             var product = _products.FirstOrDefault(p => p.ProductID == id);
             if (product == null)
                 return NotFound();

             return View(product);
         }

        [HttpPost]
         public IActionResult DeleteConfirmed(int id)
         {
             var product = _products.FirstOrDefault(p => p.ProductID == id);
             if (product == null)
                 return NotFound();

             _products.Remove(product);

             return RedirectToAction("Administration");
         }

        public IActionResult Index()
        {
            return View();
        }
    }
}

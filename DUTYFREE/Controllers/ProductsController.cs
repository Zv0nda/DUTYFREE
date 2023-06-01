using DUTYFREE.Models.Products;
using Microsoft.AspNetCore.Mvc;
using DUTYFREE.ViewModels.Products;
using System.ComponentModel.DataAnnotations.Schema;
using DUTYFREE.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.SqlServer.Server;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Hosting;

namespace DUTYFREE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IWebHostEnvironment webHost)
        {
            _webHostEnvironment = webHost;
        }

        public IActionResult Administration()
        {
            var vm = new AdminViewModel();
            vm.Products = Database.GetProducts().ToList();
            vm.Products = vm.Products.OrderByDescending(n => n.ProductID).ToList();
            return View(vm);
        }

        public IActionResult Orders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = Database.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product existingProduct)
        {
            var updatedProduct = Database.GetProductById(existingProduct.ProductID);
            if (updatedProduct == null)
                return NotFound();

            updatedProduct.Name = existingProduct.Name;
            updatedProduct.Price = existingProduct.Price;
            updatedProduct.Quantity = existingProduct.Quantity;
            updatedProduct.ImageUrl = existingProduct.ImageUrl;

            Database.EditProduct(existingProduct.ProductID, existingProduct.Name, existingProduct.ImageUrl, existingProduct.Quantity, existingProduct.Price);
            return RedirectToAction("Administration");
        }

        private string UploadImage(Product product)
        {
            string uniqueFileName = "Images/";
            if (product.Image != null)
            {
                uniqueFileName = product.Image.FileName;
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + uniqueFileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.Image.CopyToAsync(fileStream);
                }
                uniqueFileName = "Images/" + uniqueFileName;
            }

            return uniqueFileName;
        }

            [HttpPost]
        public IActionResult Insert(Product product)
        { 
            Database.InsertProduct(product.Name, UploadImage(product), product.Quantity, product.Price);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product product = Database.GetProductById(id);
            if (product is null) return NotFound();

            using (var connection = new SqlConnection(Database.connectionString))
            {
                connection.Execute("ProcProductDelete", new { ProductId = id }, commandType: CommandType.StoredProcedure);
            }
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
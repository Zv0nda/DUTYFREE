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

namespace DUTYFREE.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Administration()
        {
            var vm = new AdminViewModel();
            vm.Products = Database.GetProducts().ToList();
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


        [HttpPost]
        public IActionResult Insert(Product product)
        {
            Database.InsertProduct(product.Name, product.ImageUrl, product.Quantity, product.Price);
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
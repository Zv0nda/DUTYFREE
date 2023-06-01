using DUTYFREE.Data;
using DUTYFREE.Models.Users;
using DUTYFREE.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace DUTYFREE.Controllers
{
    namespace DUTYFREE.Controllers
    {
        public class SecurityController : Controller
        {

            // GET: /Security/Index
            public ActionResult Index()
            {
                var vm = new UsersViewModel();
                vm.Users = Database.GetAllUsers();
                return View(vm);
            }

            // GET: /Security/Login
            public ActionResult Login()
            {
                return View();
            }

            /*// POST: /Security/Login
            [HttpPost]
            public ActionResult Login(string username, string password)
            {
                var vm = new UsersViewModel();
                vm.Users = Database.GetAllUsers().ToList();
                User user = vm.Users.Find(u => u.Name == username);
                if (user != null)
                {
                    // Store user information in session or issue a token for authentication
                    // For simplicity, let's assume you're using session-based authentication
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("UserRole", user.Role.ToString());

                    return RedirectToAction("Index", "Home");
                }

                // If authentication fails, display an error message or redirect back to the login page with an error flag
                TempData["ErrorMessage"] = "Invalid username or password.";
                return RedirectToAction("Login");
            }*/

            // GET: /Security/Logout
            public ActionResult Logout()
            {
                // Clear the session or token information for the current user
                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}

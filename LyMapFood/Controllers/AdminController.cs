using Microsoft.AspNetCore.Mvc;
using LyMapFood.Models;

namespace LyMapFood.Controllers
{
    public class AdminController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Sữa Đậu Nành Tươi", Price = 15000, Calo = 120, Category = "sua", ImageUrl = "https://images.unsplash.com/photo-1618160702438-9b02ab6515c9?auto=format&fit=crop&w=600&q=80" },
            new Product { Id = 2, Name = "Sữa Bắp Tươi Béo Ngậy", Price = 18000, Calo = 160, Category = "sua", ImageUrl = "https://images.unsplash.com/photo-1551024709-8f23befc6f87?auto=format&fit=crop&w=600&q=80" },
            new Product { Id = 3, Name = "Cơm Cháy Siêu Chà Bông", Price = 35000, Calo = 350, Category = "comchay", ImageUrl = "https://images.unsplash.com/photo-1601050690597-df0568f70950?auto=format&fit=crop&w=600&q=80" }
        };

        // 1. TRANG DANG NHAP ADMIN
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Tài khoản test: admin / 123456
            if (username == "admin" && password == "123456")
            {
                HttpContext.Session.SetString("AdminUser", username);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }

        // Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUser");
            return RedirectToAction("Login");
        }

        // 2. TRANG DASHBOARD ADMIN (Cần đăng nhập)
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
            {
                return RedirectToAction("Login");
            }
            return View(_products);
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminUser") == null) return RedirectToAction("Login");
            var product = _products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var product = _products.FirstOrDefault(p => p.Id == model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Calo = model.Calo;
                product.ImageUrl = model.ImageUrl;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminUser") == null) return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            model.Id = _products.Max(p => p.Id) + 1;
            _products.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Orders()
        {
            if (HttpContext.Session.GetString("AdminUser") == null) return RedirectToAction("Login");
            return View();
        }
    }
}
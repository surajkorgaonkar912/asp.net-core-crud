using Microsoft.AspNetCore.Mvc;
using MVC6Crud.Data;
using MVC6Crud.Models;
using System.Diagnostics;

namespace MVC6Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly clsDB_Product _clsDB_Product;
        public HomeController(ILogger<HomeController> logger, clsDB_Product clsProdService)
        {
            _logger = logger;
            _clsDB_Product = clsProdService;
        }

        public IActionResult Index()
        {
            //return View();
            var products = _clsDB_Product.GetProductList();// _productService.GetAllProducts(); // Assuming this returns List<ProductListViewModel>
            return View(products);
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
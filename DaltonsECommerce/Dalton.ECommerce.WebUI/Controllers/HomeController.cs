using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dalton.DomainLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dalton.ECommerce.WebUI.Models;

namespace Dalton.ECommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            bool isPreferredCustomer = this.User.IsInRole("PreferredCustomer");

            var service = new ProductService();

            var products = service.GetFeaturedProducts(isPreferredCustomer);

            this.ViewData["Products"] = products;

            return this.View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
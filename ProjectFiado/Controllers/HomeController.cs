using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProjectFiado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            return View();
        }

    }
}

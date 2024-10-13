using Microsoft.AspNetCore.Mvc;
using ProjectFiado.Repository.Interfaces;

namespace ProjectFiado.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepository;
        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

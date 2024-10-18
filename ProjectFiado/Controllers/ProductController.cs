using Microsoft.AspNetCore.Mvc;
using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Services;

namespace ProjectFiado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] RequestProductDTO requestProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createProduct = await _productService.CreateProduct(requestProductDTO);
            return CreatedAtAction(nameof(GetById), new {id = createProduct.Id}, createProduct);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productId = await _productService.GetById(id);
            return Ok(productId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Exceptions;
using ProjectFiado.Models;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Services;
using Serilog;
using System.Collections.Generic;

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
            return CreatedAtAction(nameof(GetById), new { id = createProduct.Id }, createProduct);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productId = await _productService.GetById(id);
            return Ok(productId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] RequestProductDTO requestProductDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updateProduct = await _productService.UpdateProduct(id, requestProductDTO);
                return Ok(updateProduct);
            }
            catch (ProductExceptions ex)
            {
                Log.Error($"Error while updating product: {ex}");
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjectFiado.Domain.Models.DTOs.StockDTOS;
using ProjectFiado.Services;
using Serilog;

namespace ProjectFiado.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> createProductInStock([FromBody] RequestStockDTO requestStockDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdProduct = await _stockService.AddProduct(requestStockDTO.ProductId, requestStockDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productId = await _stockService.GetById(id);
            return Ok(productId);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInStock(int id)
        {
            var productId = await _stockService.RemoveProductInStock(id);
            return Ok(productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterQuantity(int id, [FromBody] int quantity)
        {
            try
            {
                // Chama o serviço para alterar a quantidade do produto
                var response = await _stockService.AlterProductQuantity(id, quantity);

                // Retorna um status 200 OK com o DTO de resposta
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                // Retorna 404 Not Found se o produto não for encontrado
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Retorna 500 Internal Server Error para outros erros
                return StatusCode(500, ex.Message);
            }
        }


    }
}

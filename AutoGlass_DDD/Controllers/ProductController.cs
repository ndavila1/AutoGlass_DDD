using DDD.Application.Interfaces;
using DDD.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass_DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
                var product = await this._productService.GetProductById(id);
                if(product is null)
                    return NotFound();
                return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductViewModelInput productViewModelInput)
        {

            var result = await this._productService.AddProduct(productViewModelInput);
            if (result.IsValid)
            {
                return Ok(new { Message = result.Message, Status = true });
            }
                return BadRequest(new { Message = result.Message, Status = false });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductViewModelInput productViewModelInput)
        {
            var result = await this._productService.UpdateProduct(id, productViewModelInput);
            if (result.IsValid)
            {
                return Ok(new { Message = result.Message, Status = true });
            }
            return BadRequest(new { Message = result.Message, Status = false });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await this._productService.DeleteProduct(id);
            if (result.IsValid)
            {
                return Ok(new { Message = result.Message, Status = true });
            }
            return NotFound(new { Message = result.Message, Status = false });
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<ActionResult> Pagination(int? page)
        {
            var product = await this._productService.GetAllProducts(page);
            return Ok(product);
        }

    }
}

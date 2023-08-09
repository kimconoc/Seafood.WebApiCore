using Microsoft.AspNetCore.Mvc;
using Seafood.Application.Services.Common;
using Seafood.Data.Dtos;
using Seafood.Data.Entities;

namespace Seafood.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericService<ProductVM ,ProductRequest> _productService;

        public ProductsController(IGenericService<ProductVM, ProductRequest> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productService.GetAll();
            return Ok(categories);
        }

        [HttpPost]
        [Seafood.WebApi.Configurations.Authorize(Role.Admin)]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            try
            {
                return Ok(_productService.Create(request));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [Seafood.WebApi.Configurations.Authorize(Role.Admin)]
        public async Task<IActionResult> Update(Guid id, [FromForm] ProductRequest request)
        {

            try
            {
                await _productService.Update(id, request);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Seafood.WebApi.Configurations.Authorize(Role.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.Delete(id);
                return Ok("Xóa thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

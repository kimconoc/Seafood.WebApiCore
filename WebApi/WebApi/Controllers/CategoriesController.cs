using Microsoft.AspNetCore.Mvc;
using Seafood.Application.Services.Common;
using Seafood.Data.Dtos;
using Seafood.Data.Entities;

namespace Seafood.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericService<CategoryVM ,CategoryRequest> _categoryRepository;
        public CategoriesController(IGenericService<CategoryVM, CategoryRequest> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchTerm)
        {
            var categories = await _categoryRepository.GetAll(searchTerm);
            return Ok(categories);
        }

        //[HttpPost("{name}")]
        //public async Task<IActionResult> Search(string? name)
        //{
        //    var categories = await _categoryRepository.Search(name);
        //    return Ok(categories);
        //}

        [HttpPost]
        [Seafood.WebApi.Configurations.Authorize(Role.Admin)]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            try
            {
                return Ok(_categoryRepository.Create(request));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [Seafood.WebApi.Configurations.Authorize(Role.Admin)]
        public async Task<IActionResult> Update(Guid id, CategoryRequest request)
        {

            try
            {
                await _categoryRepository.Update(id, request);
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
                await _categoryRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

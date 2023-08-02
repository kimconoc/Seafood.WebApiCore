using DoMains.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeafoodServices.Interfaces;
using SeafoodServices.Services;

namespace SeafoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("getlist")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var categoryList = await _categoryService.GetAllCategories();
            if(categoryList == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Category in database");
            }
            return StatusCode(StatusCodes.Status200OK,categoryList);
        }
        [Route("getcategorybyid")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryById([FromQuery]Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategorysDTO categoryDTO)
        {
            var isCategoryCreated= await _categoryService.CreateCategory(categoryDTO);
            if (isCategoryCreated)
            {
                return Ok(isCategoryCreated);
            }
            else
            { return BadRequest(); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategorysDTO categoryDTO)
        {
            if(categoryDTO != null)
            {
                var isUpdateCategory = await _categoryService.UpdateCategory(categoryDTO);
                if (isUpdateCategory)
                {
                    return Ok(isUpdateCategory);
                }
                return BadRequest();
            }
            return BadRequest();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            if (id != null)
            {
                var isDelete = await _categoryService.DeleteCategory(id);
                if (isDelete)
                {
                    return Ok(isDelete);
                }
            }
            return BadRequest();
        }
    }
}

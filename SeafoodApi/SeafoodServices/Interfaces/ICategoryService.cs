using DoMains.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CategorysDTO categoryDTO);
        Task<IEnumerable<CategorysDTO>> GetAllCategories();
        Task<CategorysDTO> GetCategoryById(Guid id);
        Task<bool> UpdateCategory(Guid id,CategorysDTO categoryDTO);
        Task<bool> DeleteCategory(Guid id);
        Task<IEnumerable<CategorysDTO>> GetCategoriesByName(string name);
    }
}

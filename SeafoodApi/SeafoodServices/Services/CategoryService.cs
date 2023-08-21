using AutoMapper;
using Azure;
using Azure.Core;
using DoMains.DTO;
using DoMains.Models;
using SeafoodServices.Interfaces;
using SeafoodServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Services
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper) { 
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<bool> CreateCategory(CategorysDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            if (category != null)
            {
                category.Id = Guid.NewGuid();
                category.Name = categoryDTO.Name;
                category.Code = categoryDTO.Code;
                category.Icon = categoryDTO.Icon;
                category.CreatedAt = DateTime.UtcNow;
                await _unitOfWork.Categorys.Add(category);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else return false;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            if (id != null)
            {
               var isDelete = _unitOfWork.Categorys.Delete(id);
                return true;

            }
            return false;

        }

        public async Task<IEnumerable<CategorysDTO>> GetAllCategories()
        {
            var categoryList = _unitOfWork.Categorys.GetAll();
            var reponses = categoryList.Result.Select(c => _mapper.Map<CategorysDTO>(c));
            return reponses;
        }

        public async Task<CategorysDTO> GetCategoryById(Guid id)
        {
            if (id != null)
            {
                var category = await _unitOfWork.Categorys.GetById(id);
                var categoryRp = _mapper.Map<CategorysDTO>(category);

                if (categoryRp != null)
                {
                    return categoryRp;
                }
            }
            return null;
        }

      

        public async Task<bool> UpdateCategory(Guid id,CategorysDTO categoryDTO)
        {
           if( categoryDTO != null)
            {
                var cate = await _unitOfWork.Categorys.GetById(id);
                var category = _mapper.Map<Category>(cate);
               
                if (category != null)
                {
                    category.Id = id;
                    category.Name = categoryDTO.Name;
                    category.Code = categoryDTO.Code;
                    category.Icon = categoryDTO.Icon;
                   await _unitOfWork.Categorys.Update(category);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CategorysDTO>> GetCategoriesByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var categories = await _unitOfWork.Categorys.Search(name);
                var reponses = categories.Select(c => _mapper.Map<CategorysDTO>(c));
                return reponses.ToList();

            }
            return null;
        }
    }
}

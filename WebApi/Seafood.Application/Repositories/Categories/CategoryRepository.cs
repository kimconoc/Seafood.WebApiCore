using Microsoft.EntityFrameworkCore;
using Seafood.Data.Dtos;
using Seafood.Data.EF;
using Seafood.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SeafoodDbcontext _context;

        public CategoryRepository(SeafoodDbcontext context)
        {
            _context = context;
        }

        public async Task<CategoryVM> Create(CategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                Note = request.Note,
                Code = request.Code,
                Icon = request.Icon,
                IsDeleted = false,
                DeletedAt = DateTime.Now,
                DeletedBy = "admin",
                CreatedAt = DateTime.Now,
                CreatedBy = "admin",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "admin",
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CategoryVM
            {
                Name = category.Name,
                Description = category.Description,
                Code = category.Code,
                Note = category.Note,
                Icon = category.Icon
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category == null) throw new Exception($"Không thể tìm thấy!");
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<CategoryVM>> GetAll()
        {
            var query = _context.Categories.Select(cat => new CategoryVM
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
                Note = cat.Note,
                Code = cat.Code,
                Icon = cat.Icon,
            });

            return await query.ToListAsync();

        }

        public async Task<bool> Update(Guid id, CategoryRequest request)
        {
            var category = await _context.Categories.SingleAsync(x => x.Id == id);
            if (category == null) throw new Exception($"Không thể tìm thấy!");

                category.Name = request.Name;
                category.Description = request.Description;
                category.Note = request.Note;
                category.Code = request.Code;
                category.Icon = request.Icon;
                category.IsDeleted = false;
                category.DeletedAt = DateTime.Now;
                category.DeletedBy = "admin";
                category.CreatedAt = DateTime.Now;
                category.CreatedBy = "admin";
                category.UpdatedAt = DateTime.Now;
                category.UpdatedBy = "admin";
            _context.SaveChanges();
            return true;

        }
    }
}

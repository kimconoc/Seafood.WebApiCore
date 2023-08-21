using DoMains.AppDbContext;
using DoMains.DTO;
using DoMains.Models;
using Microsoft.EntityFrameworkCore;
using SeafoodServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Repositories
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SeafoodContext context):base(context) { }

        public async Task<IEnumerable<Category>> Search(string name)
        {
            IQueryable<Category> query = _context.Categorys; 

            if (!string.IsNullOrEmpty(name))
            {
                var result = query.Where(a => a.Name.ToLower().Contains(name.ToLower()));
                return result;
            }
            return null;
        }

    }
}

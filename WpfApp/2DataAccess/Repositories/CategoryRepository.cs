using _2DataAccess.Interfaces;
using DataAccess.Repositories;
using Model.AppDbContexts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SeafoodContext context) : base(context) { }
    }
}

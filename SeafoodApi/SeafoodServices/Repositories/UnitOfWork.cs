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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SeafoodContext _context;
        public ICategoryRepository Categorys { get; set; }
        public IUserRepository Users { get; set; }
        public UnitOfWork(SeafoodContext context,
                            ICategoryRepository categoryRepository,
                            IUserRepository userRepositories)
        {
            _context = context;
            Categorys = categoryRepository;
            Users = userRepositories;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}

using DoMains.AppDbContext;
using Microsoft.EntityFrameworkCore;
using SeafoodServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SeafoodContext _context;
        protected GenericRepository(SeafoodContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(Guid id)
        {
      
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public async Task<T> Delete(Guid id)
        {
            var entityEntry = _context.Set<T>().FindAsync(id);
            var isDelete = _context.Set<T>().Remove(entityEntry.Result);
            await _context.SaveChangesAsync();
            return isDelete.Entity ;
        }

        public async Task<T> Update(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            return entityEntry.Entity;
        }

       
    }
}

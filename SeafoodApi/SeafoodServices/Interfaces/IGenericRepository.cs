using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task<T> Delete(Guid id);
        Task<T> Update(T entity);
       

    }
}

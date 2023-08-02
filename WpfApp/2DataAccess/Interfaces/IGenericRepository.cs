using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);

        bool IsExisted(Expression<Func<T, bool>> expression);
    }
}

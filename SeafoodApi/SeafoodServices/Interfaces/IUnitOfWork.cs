using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Categorys { get; set; }
        IUserRepository Users { get; set; }
        int Save();
    }
}

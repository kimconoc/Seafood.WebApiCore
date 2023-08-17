using Seafood.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Services.Common
{
    public interface IGenericService<X, Y> where X : class where Y : class
    {
        Task<List<X>> GetAll(string? searchTerm);
        //Task<List<X>> Search(string? name);
        Task<X> Create(Y request);
        Task<bool> Update(Guid id,Y request);
        Task<bool> Delete(Guid id);
    }
}

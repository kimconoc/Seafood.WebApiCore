using Seafood.Data.Dtos;
using Seafood.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Services.Users
{
    public interface IUserService
    {
        Task<User> Authenticate(LoginRequest request);
        Task<User> GetUserById(Guid id);
    }
}

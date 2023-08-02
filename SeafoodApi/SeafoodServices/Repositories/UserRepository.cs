using DoMains.AppDbContext;
using DoMains.DTO;
using DoMains.Models;
using SeafoodServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(SeafoodContext context):base(context) { }

    }
}

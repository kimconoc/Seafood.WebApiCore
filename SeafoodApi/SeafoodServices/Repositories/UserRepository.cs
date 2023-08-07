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
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(SeafoodContext context):base(context) {
        
        
        }

        public async Task<bool> CheckEmailSignUp(string email)
        {
           return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CheckUserNameSignUp(string username)
        {
           return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}

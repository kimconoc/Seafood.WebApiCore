using AutoMapper;
using DoMains.AppDbContext;
using DoMains.DTO;
using DoMains.Models;
using SeafoodServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Azure.Core;
using Microsoft.VisualBasic;

namespace SeafoodServices.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SeafoodContext _context;
        
        public UserService(IMapper mapper, IUnitOfWork unitOfWork,SeafoodContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public Task<bool> CreateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
           var userList = _unitOfWork.Users.GetAll();
           var userReponse = userList.Result.Select(c=>_mapper.Map<UserDTO>(c));
           return userReponse;
           
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            if (id != null)
            {
                var user = await _unitOfWork.Users.GetById(id);
                var userRp = _mapper.Map<UserDTO>(user);

                if (userRp != null)
                {
                    return userRp;
                }
            }
            return null;
        }

        public Task<bool> UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetUserToContext(Guid id)
        {
            return await _unitOfWork.Users.GetById(id);
        }

        public Task<bool> CheckEmailSignUp(string email)
        {
            return _unitOfWork.Users.CheckEmailSignUp(email);
        }
        public async Task<UserDTO> SignIn(SignIn signin)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == signin.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(signin.Password, user.PasswordHash))
            {
                throw new Exception("Username or password is incorrect");
            }
            return _mapper.Map<UserDTO>(user);
        }
        public Task<bool> CheckUserNameSignUp(string userName)
        {
            return _unitOfWork.Users.CheckUserNameSignUp(userName);
        }
        public async Task<bool> SignUp(SignUp signUp)
        {
           if(await _unitOfWork.Users.CheckEmailSignUp(signUp.Email)|| await _unitOfWork.Users.CheckUserNameSignUp(signUp.Username))
            {
                throw new Exception("Email or UserName already exist");
            }
           var user = _mapper.Map<User>(signUp);
            if(user!=null)
            {
                user.Id = Guid.NewGuid();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(signUp.Password);
                user.DisplayName = signUp.DisplayName;
                user.Avarta = signUp.Avarta;
                user.Birthday = signUp.Birthday;
                user.Sex = signUp.Sex;
                user.Mobile = signUp.Mobile;
                user.Email = signUp.Email;
                user.Company = signUp.Company;
                user.Roles = "User";
                user.CreatedAt = DateTime.UtcNow;
                user.CreatedBy = "dev-local";
                await _unitOfWork.Users.Add(user);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else return false;
            }
           return false;

        }
    }
}

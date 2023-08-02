using AutoMapper;
using DoMains.DTO;
using DoMains.Models;
using SeafoodServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public Task<UserDTO> SignIn(SignIn signin)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> SignUp(SignUp signUp)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserToContext(Guid id)
        {
            return await _unitOfWork.Users.GetById(id);
        }
    }
}

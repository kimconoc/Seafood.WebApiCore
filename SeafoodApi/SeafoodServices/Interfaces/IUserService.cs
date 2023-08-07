using DoMains.DTO;
using DoMains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> SignIn(SignIn signin);
        Task<bool> SignUp(SignUp signUp);
        Task<bool> CreateUser(UserDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserById(Guid id);
        Task<bool> UpdateUser(UserDTO userDTO);
        Task<bool> DeleteUser(Guid id);
        Task<User> GetUserToContext(Guid id);
        Task<bool> CheckEmailSignUp(string email);
        Task<bool> CheckUserNameSignUp(string userName);

    }
}

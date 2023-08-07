using DoMains.DTO;
using DoMains.Models;

namespace SeafoodApi.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserDTO user);
        public Guid? ValidateJwtToken(string token);
    }
}

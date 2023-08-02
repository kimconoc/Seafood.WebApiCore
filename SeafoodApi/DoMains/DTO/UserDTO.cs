using DoMains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMains.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? DisplayName { get; set; }

        public string? Avarta { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Sex { get; set; }

        public string Mobile { get; set; } = null!;

        public string? Email { get; set; }

        public string? Company { get; set; }

        public string? Roles { get; set; }
        public UserDTO(User user) {

            Id = user.Id;
            Username = user.Username;
            DisplayName = user.DisplayName;
            Avarta = user.Avarta;
            Birthday = user.Birthday;
            Sex = user.Sex;
            Mobile = user.Mobile;
            Email = user.Email;
            Company = user.Company;
            Roles = user.Roles;
        }
    }
}

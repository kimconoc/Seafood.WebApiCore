using AutoMapper;
using DoMains.Models;
using DoMains.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Mappers
{
    public class UserMapper:Profile
    {
        public UserMapper() {
            CreateMap<User, SignIn>().ReverseMap();
            CreateMap<User, SignUp>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
        }
    }
}

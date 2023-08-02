using DoMains.DTO;
using DoMains.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.Mappers
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper() {
            CreateMap<Category, CategorysDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using Seafood.Data.Dtos;
using Seafood.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Category, CategoryRequest>().ReverseMap();
        }
    }
}

using AutoMapper;
using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserForCreationDto>().ReverseMap();
            // Product
            CreateMap<Product, ProductForCreationDto>().ReverseMap();
        }
    }
}

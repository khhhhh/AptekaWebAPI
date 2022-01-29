using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AptekaWebAPI.DTO;
using AptekaWebAPI.Entities;
using AptekaWebAPI.Properties.DTOs;

namespace AptekaWebAPI.AutoMapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateProductDTO, Product>();
                cfg.CreateMap<CreateProductDTO, Product>();
                cfg.CreateMap<UpdateUserDTO, User>();
                cfg.CreateMap<CreateUserDTO, User>();
            }).CreateMapper();
        }
    }
}

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
                cfg.CreateMap<CreateProductDTO, Product>();
                cfg.CreateMap<UpdateProductDTO, Product>();
                cfg.CreateMap<UpdateUserDTO, User>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<CategoryDTO, ProductCategory>();
                cfg.CreateMap<CreateCategoryDTO, ProductCategory>();
                cfg.CreateMap<Cart, CartDTO>();

                cfg.CreateMap<CartDTO, Cart>();
                
                cfg.CreateMap<CreateUserDTO, User>()
               .ForMember(c => c.Address, r => r.MapFrom(dto => new Address()
               {
                   City = dto.City,
                   Street = dto.Street,
                   PostalCode = dto.PostalCode
               }));
            }).CreateMapper();
        }
    }
}

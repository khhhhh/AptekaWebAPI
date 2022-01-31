﻿using AptekaWebAPI.Entities;
using AptekaWebAPI.Database;
using AptekaWebAPI.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services.Models
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly PharmacyContext _context;
        public CartService(IMapper mapper, PharmacyContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void AddById(int UserId, AddToCartDTO dto)
        {
            var selectedProduct = _context.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (selectedProduct == null) throw new Exception();
            var user = _context.Users.Where(x => x.Id == UserId).FirstOrDefault();
            if(user == null) throw new Exception();
            var cart = new CartDTO()
            {
                Count = dto.Count,
                UserId = UserId,
                ProductId = selectedProduct.Id,
                Price = selectedProduct.Price,
                Name = selectedProduct.Name,
            };

            var newCart = _mapper.Map<Cart>(cart);
            _context.Carts.Add(newCart);
            _context.SaveChanges();
        }

        public IEnumerable<CartDTO> GetAll(int userId)
        {
            var product = _context.Carts.ToList().FirstOrDefault();

            var products = _context.Carts.ToList().Where(x => x.UserId == userId);
            if (products == null) throw new Exception();

            return _mapper.Map<List<CartDTO>>(products);
        }

        public CartDTO GetByID(int id)
        {
            var product = _context.Carts.ToList().Where(x => x.Id == id);
            if (product == null) throw new Exception();
            return _mapper.Map<CartDTO>(product);
        }

        public void RemoveById(int id)
        {

            var selectedCart = _context.Carts.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (selectedCart == null) throw new Exception();

            _context.Carts.Remove(selectedCart);
            _context.SaveChanges();
        }


        public void Modify(AddToCartDTO dto)
        {
            var selectedCart = _context.Carts.ToList().Where(x => x.Id == dto.Id).FirstOrDefault();
            if(selectedCart == null) throw new Exception();

            selectedCart.Count = dto.Count;
            _context.SaveChanges();
        }

    }
}

using AptekaWebAPI.Database;
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
        public void AddById(int id)
        {
            var selectedProduct = _context.Products.Where(x => x.Id == id);
            if (selectedProduct == null) throw new Exception();

            //_context.Carts.Add()
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

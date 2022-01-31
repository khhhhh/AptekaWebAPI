using AptekaWebAPI.Database;
using AptekaWebAPI.Properties.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services.Models
{
    public class PharmacyUserService : IPharmacyUserService
    {
        private readonly IMapper _mapper;
        private readonly PharmacyContext _context;
        public PharmacyUserService(IMapper mapper, PharmacyContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _context
                .Products
                .Include(r => r.Categories)
                .ToList();

            if (products == null) throw new Exception();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetById(int id)
        {
            var product = _context
               .Products
               .Include(r => r.Categories)
               .ToList()
               .Where(x => x.ProductId == id).FirstOrDefault();

            if (product == null) throw new Exception();

            return _mapper.Map<ProductDTO>(product);
        }

    }
}

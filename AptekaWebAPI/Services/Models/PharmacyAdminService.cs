using AptekaWebAPI.Database;
using AptekaWebAPI.Properties.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services.Models
{
    public class PharmacyAdminService : IPharmacyAdminService
    {
        private readonly IMapper _mapper;
        private readonly PharmacyContext _context;
        public PharmacyAdminService(IMapper mapper, PharmacyContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Modify(UpdateProductDTO dto)
        {
            var selectedProduct = _context.Products.ToList().Where(x => x.Id == dto.Id).FirstOrDefault();
            if (selectedProduct == null) throw new Exception();
            selectedProduct.Price = dto.Price;
            _context.SaveChanges();
        }
    }
}

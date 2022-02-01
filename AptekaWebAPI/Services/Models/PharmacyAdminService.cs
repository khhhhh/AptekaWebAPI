using AptekaWebAPI.Database;
using AptekaWebAPI.Entities;
using AptekaWebAPI.Properties.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public void AddNewProduct(CreateProductDTO dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            newProduct.Categories = _mapper.Map<List<ProductCategory>>(dto.Categories);

            _context.Products.Add(newProduct);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context
                 .Products
                 .Include(r => r.Categories)
                 .ToList()
                 .Where(x => x.Id == id).FirstOrDefault();

            if (product == null) throw new Exception(Resources.productNotFound);

            _context.Products.Remove(product);

            _context.SaveChanges();

        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _context
                .Products
                .Include(r => r.Categories)
                .ToList();

            if (products == null) throw new Exception(Resources.productsNotFound);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetById(int id)
        {
            var product = _context
               .Products
               .Include(r => r.Categories)
               .ToList()
               .Where(x => x.Id == id).FirstOrDefault();

            if(product == null) throw new Exception(Resources.productNotFound);

            return _mapper.Map<ProductDTO>(product);
        }

        public void Modify(UpdateProductDTO dto)
        {
            var selectedProduct = _context.Products.ToList().Where(x => x.Id == dto.Id).FirstOrDefault();
            if (selectedProduct == null) throw new Exception(Resources.productNotFound);
            selectedProduct.Price = dto.Price;
            _context.SaveChanges();
        }
    }
}

using AptekaWebAPI.Properties.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface IPharmacyAdminService
    {
        public void AddNewProduct(CreateProductDTO dto);
        public IEnumerable<ProductDTO> GetAll();

        public ProductDTO GetById(int id);


        public void Modify(UpdateProductDTO dto);

        public void Delete(int id);
    }
}

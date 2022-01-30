using AptekaWebAPI.Properties.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface IPharmacyUserService
    {
        public IEnumerable<ProductDTO> GetAll();

        public ProductDTO GetById(int id);

        public IEnumerable<ProductDTO> GetByName(string name);

    }
}

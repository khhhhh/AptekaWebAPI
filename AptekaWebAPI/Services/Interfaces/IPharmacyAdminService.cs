using AptekaWebAPI.Properties.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface IPharmacyAdminService
    {
        public void GetAll();

        public void GetById(int id);

        public void GetByName(string name);

        public void Modify(UpdateProductDTO dto);

        public void Delete(int id);
    }
}

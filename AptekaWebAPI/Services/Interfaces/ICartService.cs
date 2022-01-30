using AptekaWebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface ICartService
    {
        public void AddById(int userId, AddToCartDTO dto);

        public void RemoveById(int id);

        public IEnumerable<CartDTO> GetAll(int userId);

        public CartDTO GetByID(int id);

        public void Modify(AddToCartDTO dto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface ICartService
    {
        public void AddById(int id);

        public void RemoveById(int id);

        public void Modify(int id);

        public void GetAll();

        public void GetByID(int id);
    }
}

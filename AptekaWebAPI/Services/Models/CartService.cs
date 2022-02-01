using AptekaWebAPI.Entities;
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
            if (selectedProduct == null) throw new Exception(Resources.productNotFound);
            var user = _context.Users.Where(x => x.Id == UserId).FirstOrDefault();


            if(user == null) throw new Exception();

            // check if enougth quantity
            if (dto.Count > selectedProduct.Count)
                throw new Exception(string.Format("{0} For now, we have {1} piece{2} of {3}",
                    Resources.notEnougthProducts,
                    selectedProduct.Count,
                    (selectedProduct.Count == 1)? string.Empty: "s",
                    selectedProduct.Name
                    ));
            if (AddIfExist(user, dto))
                return;

            var cart = new CartDTO()
            {
                Count = dto.Count,
                UserId = UserId,
                ProductId = selectedProduct.Id,
                ProductPrice = selectedProduct.Price * dto.Count,
                ProductName = selectedProduct.Name,
            };

            selectedProduct.Count -= cart.Count;

            var newCart = _mapper.Map<Cart>(cart);
            _context.Carts.Add(newCart);
            _context.SaveChanges();

        }

        public IEnumerable<CartDTO> GetAll(int userId)
        {

            var products = _context.Carts.ToList().Where(x => x.UserId == userId);
            if (products == null) throw new Exception(Resources.emptyCart);

            return _mapper.Map<List<CartDTO>>(products);
        }

        public CartDTO GetByID(int id)
        {
            var product = _context.Carts.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (product == null) throw new Exception(Resources.productNotFound);
            return _mapper.Map<CartDTO>(product);
        }

        public void RemoveById(int id)
        {

            var selectedCart = _context.Carts.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (selectedCart == null) throw new Exception(Resources.emptyCart);

            // select product, check if exists and add quantity
            var selectedProduct = _context.Products.ToList().Where(x => x.Id == selectedCart.ProductId).FirstOrDefault();
            if (selectedProduct == null) throw new Exception(Resources.productNotFound);
            selectedProduct.Count += selectedCart.Count;

            _context.Carts.Remove(selectedCart);
            _context.SaveChanges();
        }


        public void Modify(AddToCartDTO dto)
        {
            var selectedCart = _context.Carts.ToList().Where(x => x.Id == dto.Id).FirstOrDefault();
            if(selectedCart == null) throw new Exception(Resources.productNotFound);

            //var product = _context.Products.Where(x => x.Id == selectedCart.ProductId).FirstOrDefault();

       
            var price = _context.Products.Where(x => x.Id == selectedCart.ProductId).FirstOrDefault().Price;

            selectedCart.Count = dto.Count;
            selectedCart.ProductPrice = price * dto.Count;
            _context.SaveChanges();
        }

        private bool AddIfExist(User user, AddToCartDTO dto)
        {
            var existedProduct = _context
                .Carts
                .Where(
                    x => x.UserId == user.Id
                    && x.ProductId == dto.Id)
                .FirstOrDefault();

            if(existedProduct != null)
            {
                int count = existedProduct.Count + dto.Count;
                AddToCartDTO addToCartDTO = new AddToCartDTO()
                {
                    Count = count,
                    Id = existedProduct.Id
                };
                this.Modify(addToCartDTO);
                return true;
            }

            return false;
        }
    }
}

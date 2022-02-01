using AptekaWebAPI.Database;
using AptekaWebAPI.DTO;
using AptekaWebAPI.Entities;
using AptekaWebAPI.Properties.DTOs;
using AptekaWebAPI.Tokens;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services.Models
{
    public class AuthenticationService : IAutrhenticationService
    {
        private readonly IMapper _mapper;
        private readonly PharmacyContext _context;
        private readonly PharamcySeeder _seeder;
        public AuthenticationService(IMapper mapper, PharmacyContext context, PharamcySeeder seeder)
        {
            _mapper = mapper;
            _context = context;
            _seeder = seeder;
        }
        public int Logining(LoginUserDTO dto)
        {
            var hashedPassword = _seeder.getHash(dto.Password);
            var currentUser = _context.Users.ToList().Where(x => x.Email == dto.Login && x.PasswordHash == hashedPassword).FirstOrDefault();
            if (currentUser == null) throw new Exception(Resources.noUser);


            return currentUser.Id;
        }


        public int Registrating(CreateUserDTO dto)
        {
            var Users = _context.Users.ToList();

            if (Users.Where(x => x.Email == dto.Email).First() != null)
                throw new Exception(Resources.emailNotUnique);

            var addressDto = new CreateAddressDTO()
            {
                City = dto.City,
                PostalCode = dto.PostalCode,
                Street = dto.Street
            };
            var newAddress = _mapper.Map<Address>(addressDto);
            var newUser = _mapper.Map<User>(dto);
            newUser.Address = newAddress;
            newUser.PasswordHash = _seeder.getHash(dto.Password);
            _context.Users.Add(newUser);
            _context.Addresses.Add(newAddress);

            _context.SaveChanges();

            return _context.Users.ToList().Count();
        }
    }
}

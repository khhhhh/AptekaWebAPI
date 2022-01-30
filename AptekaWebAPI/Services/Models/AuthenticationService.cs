using AptekaWebAPI.Database;
using AptekaWebAPI.DTO;
using AptekaWebAPI.Entities;
using AptekaWebAPI.Properties.DTOs;
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
            if (currentUser == null) throw new Exception();


            return currentUser.Id;
        }


        public int Registrating(CreateUserDTO dto)
        {
            var count = _context.Users.ToList().Count();
            var newUser = _mapper.Map<User>(dto);
            newUser.PasswordHash = _seeder.getHash(dto.Password);
            _context.Users.Add(newUser);

            _context.SaveChanges();

            return _context.Users.ToList().Count();
        }
    }
}

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

        public AuthenticationService(IMapper mapper, PharmacyContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public int Logining(LoginUserDTO dto)
        {
            var hashedPassword = dto.Password;
            var currentUser = _context.Users.ToList().Where(x => x.Email == dto.Login && x.PasswordHash == hashedPassword).FirstOrDefault();
            if (currentUser == null) throw new Exception();


            return currentUser.Id;
        }


        public int Registrating(CreateUserDTO dto)
        {
            var newUser = _mapper.Map<User>(dto);
            _context.Users.Add(newUser);

            return _context.Users.ToList().Count();
        }
    }
}

using AptekaWebAPI.DTO;
using AptekaWebAPI.Properties.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Services
{
    public interface IAutrhenticationService
    {
        public int Registrating(CreateUserDTO dto);

        public int Logining(LoginUserDTO dto);
    }
}

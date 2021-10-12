using e_Shopping.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_e_Shopping.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();
    }
}

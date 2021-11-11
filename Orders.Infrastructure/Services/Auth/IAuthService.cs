using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);
    }
}

using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Resturants
{
    public interface IResturantService
    {
        Task<List<ResturantViewModel>> GetAll(string serachKey);
        Task<List<ResturantViewModel>> NearMe(string userId);
        Task<int> Create(CreateResturantDto dto);

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nest;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Orders.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Resturants
{
    public class ResturantService : IResturantService
    {

        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public ResturantService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<ResturantViewModel>> GetAll(string serachKey)
        {
            var resturants = await _db.Resturants.Include(x => x.Meals).Where(x => x.Name.Contains(serachKey) || string.IsNullOrEmpty(serachKey)).OrderByDescending(x => x.Meals.Count()).ToListAsync();
            return _mapper.Map<List<ResturantViewModel>>(resturants);
        }

        public async Task<int> Create(CreateResturantDto dto)
        {
            var restutant = _mapper.Map<Resturant>(dto);
            await _db.Resturants.AddAsync(restutant);
            await _db.SaveChangesAsync();
            return restutant.Id;
        }

        public async Task<List<ResturantViewModel>> NearMe(string userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var resturants = await _db.Resturants.ToListAsync();
            var distances = new Dictionary<int, double>();

            var userLocation = new Coordinates((double)user.Latitude, (double)user.Longitude);

            foreach (var resturant in resturants)
            {
                var resturantLocation = new Coordinates((double)resturant.Latitude, (double)resturant.Longitude);
                var distancKM = userLocation.DistanceTo(resturantLocation);
                distances.Add(resturant.Id, distancKM);
            }

            var nearIds = distances.OrderBy(x => x.Value).Take(5).Select(x => x.Key).ToList();

            var nearResturants = _db.Resturants.Where(x => nearIds.Contains(x.Id)).ToList();

            return _mapper.Map<List<ResturantViewModel>>(nearResturants);
        }


    }
}

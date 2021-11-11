using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Infrastructure.Services.Categories;
using Orders.Infrastructure.Services.Resturants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Controllers
{
   
    public class ResturantController : BaseController
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService categoryService)
        {
            _resturantService = categoryService;
        }

        [HttpGet]
        public ActionResult GetAll(string serachkey)
        {
           var categories = _resturantService.GetAll(serachkey);
            return Ok(GetResponse(categories));
        }

        [HttpGet]
        public IActionResult NearMe()
        {
            var category = _resturantService.NearMe(UserId);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateResturantDto dto)
        {
            var savedId = _resturantService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        

    }
}

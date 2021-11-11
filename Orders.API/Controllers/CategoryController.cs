using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Orders.Core.Constant;
using Orders.Core.Dtos;
using Orders.Core.Resourses;
using Orders.Core.ViewModels;
using Orders.Infrastructure.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Controllers
{
   
    public class CategoryController : BaseController
    {

        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<Messages> _localizedMessages;


        public CategoryController(ICategoryService categoryService, IStringLocalizer<Messages> localizedMessages)
        {
            _categoryService = categoryService;
            _localizedMessages = localizedMessages;
        }

        [HttpGet]
        public ActionResult GetAll(string serachkey)
        {
           var categories = _categoryService.GetAll(serachkey);
            return Ok(GetResponse(categories,_localizedMessages[MessagesKey.WelcomeMessage]));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryDto dto)
        {
            var savedId = _categoryService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var savedId = _categoryService.Update(dto);
            return Ok(GetResponse(savedId));
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _categoryService.Delete(id);       
            return Ok(GetResponse(deletedId));
        }

    }
}

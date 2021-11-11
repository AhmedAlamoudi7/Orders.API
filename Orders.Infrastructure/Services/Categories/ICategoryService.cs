using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string serachKey);
        Task<int> Create(CreateCategoryDto dto);
        Task<int> Update(UpdateCategoryDto dto);
        Task<int> Delete(int id);
        Task<CategoryViewModel> Get(int id);
    }
}

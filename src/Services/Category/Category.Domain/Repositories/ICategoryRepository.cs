using Category.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategoryAsync(string id);
        Task<CategoryModel> GetCategoryByTitileAsync(string title);
        Task CreateCategoryAsync(CategoryModel Category);
        Task<bool> UpdateCategoryAsync(CategoryModel Category);
        Task<bool> DeleteCategoryAsync(string id);
    }
}

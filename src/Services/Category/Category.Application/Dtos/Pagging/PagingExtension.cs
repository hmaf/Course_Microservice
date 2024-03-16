using AutoMapper;
using Category.Application.Dtos.Category;
using Category.Application.Features.Queries.GetAllCategory;
using Category.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Dtos.Pagging
{
    public static class PagingExtension
    {
        public static IEnumerable<T> Pagging<T>(this IEnumerable<T> queryable, BasePaging paging)
        {
            return queryable.Skip(paging.Skip).Take(paging.Take);
        }

        public static async Task<FilterCategoryDto> PaginateAndMap(IMapper mapper, FilterCategoryDto filter, GetAllCategoryRequest request, IEnumerable<CategoryModel> query)
        {
            // ساخت یک صفحه‌بند بر اساس پارامترهای درخواست
            var pager = Pager.Build(page: request.Page,
                                    take: request.Take,
                                    allEntitiesCount: query.Count(),
                                    filter.HowManyShowAfterBefore);

            // اعمال صفحه‌بندی به کوئری و نگاشت نتایج
            var filteredCategories = query.Pagging(pager).ToList();
            var mappedCategories = mapper.Map<List<CategoryModel>, List<CategoryDto>>(filteredCategories);

            filter.Categories = mappedCategories;

            return filter.SetPaging(pager);
        }
    }
}

using AutoMapper;
using Category.Application.Core.ApplicationError;
using Category.Application.Dtos.Category;
using Category.Application.Dtos.Pagging;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Category.Application.Features.Queries.GetAllCategory
{
    public class GetAllCategoryRequestHandler
        (IMapper mapper, ICategoryRepository categoryRepository) 
        : IRequestHandler<GetAllCategoryRequest, ErrorOr<FilterCategoryDto>>
    {

        public async Task<ErrorOr<FilterCategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = await categoryRepository.GetCategories();

            return PaginateAndMap(request, query);
        }

        #region Paging And Mapping
        private ErrorOr<FilterCategoryDto> PaginateAndMap(GetAllCategoryRequest request, IEnumerable<CategoryModel> query)
        {
            var filter = InitializeFilter();

            int allEntitiesCount = query.Count();

            // ساخت یک صفحه‌بند بر اساس پارامترهای درخواست
            var pager = Pager.Build(page: request.Filter.Page,
                                    take: request.Filter.Take,
                                    allEntitiesCount,
                                    filter.HowManyShowAfterBefore);

            // اعمال صفحه‌بندی به کوئری و نگاشت نتایج
            var filteredCategories = query.Pagging(pager).ToList();
            var mappedCategories = mapper.Map<List<CategoryModel>, List<CategoryDto>>(filteredCategories);

            // ایجاد یک FilterCategoryDto با دسته‌بندی‌های نگاشت شده و اطلاعات صفحه‌بندی
            filter.Categories = mappedCategories;

            return filter.SetPaging(pager);
        }

        private FilterCategoryDto InitializeFilter() => new FilterCategoryDto();
        #endregion


    }
}

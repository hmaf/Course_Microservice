using AutoMapper;
using Category.Application.Contracts;
using Category.Application.Dtos.Category;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Options;

namespace Category.Application.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdRequestHandler
        (IMapper mapper, ICategoryRepository categoryRepository, IOptions<AppSettings> appSettings) 
        : IRequestHandler<GetCategoryByIdRequest, ErrorOr<CategoryDto?>>
    {
        public async Task<ErrorOr<CategoryDto?>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await categoryRepository.GetCategoryAsync(request.Id);
            if (data is null)
                return Error.NotFound("category.NotFound","Category not found.");

            var category = mapper.Map<CategoryDto?>(data);
            
            category.Icon = $"{appSettings.Value.AppAddress}{appSettings.Value.File.Images}{data.Icon}";

            return category;
        }


    }
}

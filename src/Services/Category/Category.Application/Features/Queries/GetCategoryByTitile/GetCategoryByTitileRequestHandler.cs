using AutoMapper;
using Category.Application.Dtos.Category;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Category.Application.Contracts;
using Microsoft.Extensions.Options;

namespace Category.Application.Features.Queries.GetCategoryByTitile
{
    public record GetCategoryByTitileRequestHandler
        (IMapper mapper, ICategoryRepository categoryRepository, IOptions<AppSettings> appSettings)
        : IRequestHandler<GetCategoryByTitileRequest, ErrorOr<CategoryDto?>>
    {
        public async Task<ErrorOr<CategoryDto?>> Handle(GetCategoryByTitileRequest request, CancellationToken cancellationToken)
        {
            var data = await categoryRepository.GetCategoryByTitileAsync(request.Title);
            if (data is null)
                return Error.NotFound("Category_NotFound", $"موجودیتی با عنوان {request.Title} یافت نشد");

            var category = mapper.Map<CategoryDto?>(data);

            category.Icon = $"{appSettings.Value.AppAddress}{appSettings.Value.File.Images}{data.Icon}";

            return category;
        }
    }
}

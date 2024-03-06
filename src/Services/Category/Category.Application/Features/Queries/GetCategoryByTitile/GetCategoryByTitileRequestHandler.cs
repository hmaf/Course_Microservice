using AutoMapper;
using Category.Application.Exception;
using Category.Application.Dtos.Category;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Queries.GetCategoryByTitile
{
    public record GetCategoryByTitileRequestHandler
        (IMapper mapper, ICategoryRepository categoryRepository)
        : IRequestHandler<GetCategoryByTitileRequest, ErrorOr<CategoryDto?>>
    {
        public async Task<ErrorOr<CategoryDto?>> Handle(GetCategoryByTitileRequest request, CancellationToken cancellationToken)
        {
            var data = await categoryRepository.GetCategoryByTitileAsync(request.Title);
            if (data is null)
                return Error.NotFound("Category_NotFound", $"موجودیتی با عنوان {request.Title} یافت نشد");

            var category = mapper.Map<CategoryDto?>(data);

            return category;
        }
    }
}

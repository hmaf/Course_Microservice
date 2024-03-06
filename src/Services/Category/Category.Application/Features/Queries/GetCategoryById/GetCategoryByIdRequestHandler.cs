using AutoMapper;
using Category.Application.Dtos.Category;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
namespace Category.Application.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdRequestHandler
        (IMapper mapper, ICategoryRepository categoryRepository) 
        : IRequestHandler<GetCategoryByIdRequest, ErrorOr<CategoryDto?>>
    {
        public async Task<ErrorOr<CategoryDto?>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await categoryRepository.GetCategoryAsync(request.Id);
            var category = mapper.Map<CategoryDto?>(data);
            return category;
        }
    }
}

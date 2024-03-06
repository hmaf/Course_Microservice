using Category.Application.Dtos.Category;
using ErrorOr;
using MediatR;

namespace Category.Application.Features.Queries.GetCategoryById
{
    public record GetCategoryByIdRequest(string Id) : IRequest<ErrorOr<CategoryDto?>>
    {
    }
}

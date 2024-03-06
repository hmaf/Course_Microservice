using Category.Application.Dtos.Category;
using ErrorOr;
using MediatR;

namespace Category.Application.Features.Queries.GetCategoryByTitile
{
    public record GetCategoryByTitileRequest(string Title)
        : IRequest<ErrorOr<CategoryDto?>>
    {
    }
}

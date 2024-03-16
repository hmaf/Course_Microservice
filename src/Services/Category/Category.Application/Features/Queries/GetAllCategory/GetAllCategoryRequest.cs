using Category.Application.Dtos.Category;
using Category.Application.Dtos.Pagging;
using ErrorOr;
using MediatR;

namespace Category.Application.Features.Queries.GetAllCategory
{
    public record GetAllCategoryRequest(int Page, int Take) : IRequest<ErrorOr<FilterCategoryDto?>>
    {
    }
}

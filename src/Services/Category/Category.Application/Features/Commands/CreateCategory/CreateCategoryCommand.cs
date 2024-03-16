using Category.Application.Dtos.File;
using Category.Domain.Entity;
using ErrorOr;
using MediatR;

namespace Category.Application.Features.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Title, string ShorDescription, string LongDescription, FileB64? File) : IRequest<ErrorOr<string>>
    {
        
    }
}

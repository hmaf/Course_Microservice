using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(string Id) : IRequest<ErrorOr<string>>
    {
    }
}

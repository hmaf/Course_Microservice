using ErrorOr;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<ErrorOr<string>>
    {
        public string Id { get; set; } = BsonObjectId.GenerateNewId().ToString();
        public string Title { get; set; }
        public string ShorDescription { get; set; }
        public string LongDescription { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}

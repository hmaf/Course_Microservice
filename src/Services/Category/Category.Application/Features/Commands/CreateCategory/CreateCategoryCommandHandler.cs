using AutoMapper;
using Category.Application.Dtos.File;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Net.Http;

namespace Category.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger)
        : IRequestHandler<CreateCategoryCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<CategoryModel>(request);
            await categoryRepository.CreateCategoryAsync(category);

            logger.LogInformation($"category {request.Title} is successfuly created");
            return category.Id;
        }

        
               
    }
}

using AutoMapper;
using Category.Application.Exception;
using Category.Application.Features.Commands.CreateCategory;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger)
        : IRequestHandler<UpdateCategoryCommand, ErrorOr<string>>
    {

        public async Task<ErrorOr<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryAsync(request.Id.ToString());
            if (category is null)
                return Error.NotFound(nameof(CategoryModel), $"{request.Id} not found"); 

            mapper.Map(request, category, typeof(UpdateCategoryCommand), typeof(CategoryModel));
            await categoryRepository.UpdateCategoryAsync(category);

            logger.LogInformation($"category {request.Id} is successfuly updated");
            return category.Id;
        }
    }
}

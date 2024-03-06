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

namespace Category.Application.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger) 
        : IRequestHandler<DeleteCategoryCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryAsync(request.Id);
            if (category is null)
                return Error.NotFound("Category_NotFound", $"موجودیتی با شناسه \n '{request.Id}' \n یافت نشد");

            await categoryRepository.DeleteCategoryAsync(request.Id);

            logger.LogInformation($"category {request.Id} is successfuly deleted");

            return request.Id;
        }
    }
}

using AutoMapper;
using Category.Application.Contracts;
using Category.Application.Dtos.File;
using Category.Application.Servcies.IServices;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Category.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, 
         ILogger<CreateCategoryCommandHandler> logger, IFileService fileService,
         IOptions<AppSettings> appSettings)
        : IRequestHandler<CreateCategoryCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<CategoryModel>(request);
            category.Icon = await UploadFile(request.File);
            await categoryRepository.CreateCategoryAsync(category);

            logger.LogInformation($"category {request.Title} is successfuly created");
            return category.Id;
        }

        private async Task<string> UploadFile(FileB64 file)
        {
            var image = await fileService.UploadFile(file, appSettings.Value.File.Images);

            return image;
        }

    }
}

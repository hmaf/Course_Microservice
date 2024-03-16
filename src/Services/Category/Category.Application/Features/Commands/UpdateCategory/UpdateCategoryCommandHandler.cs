using AutoMapper;
using Category.Application.Contracts;
using Category.Application.Dtos.File;
using Category.Application.Exception;
using Category.Application.Features.Commands.CreateCategory;
using Category.Application.Servcies;
using Category.Application.Servcies.IServices;
using Category.Domain.Entity;
using Category.Domain.Repositories;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, 
        ILogger<CreateCategoryCommandHandler> logger, IFileService fileService,
        IOptions<AppSettings> appSettings)
        : IRequestHandler<UpdateCategoryCommand, ErrorOr<string>>
    {

        public async Task<ErrorOr<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryAsync(request.Id.ToString());
            if (category is null)
                return Error.NotFound(nameof(CategoryModel), $"{request.Id} not found"); 

            mapper.Map(request, category, typeof(UpdateCategoryCommand), typeof(CategoryModel));

            category.Icon = await UploadFile(request.File, category.Icon);

            await categoryRepository.UpdateCategoryAsync(category);

            logger.LogInformation($"category {request.Id} is successfuly updated");
            return category.Id;
        }
        private async Task<string> UploadFile(FileB64 file, string Icon)
        {
            if (file is null || file.File == "string" || string.IsNullOrEmpty(file.File)) return Icon;
            fileService.Delete(Icon, appSettings.Value.File.Images);
            var image = await fileService.UploadFile(file, appSettings.Value.File.Images);

            return image;
        }
    }
}

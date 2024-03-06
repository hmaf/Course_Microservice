using AutoMapper;
using Category.Application.Features.Commands.CreateCategory;
using Category.Application.Features.Commands.UpdateCategory;
using Category.Application.Dtos.Category;
using Category.Domain.Entity;

namespace Category.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, CategoryModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryModel>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryModel>().ReverseMap();
        }
    }
}

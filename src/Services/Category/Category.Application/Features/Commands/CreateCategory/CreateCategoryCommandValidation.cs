using Category.Application.Core.ApplicationError;
using FluentValidation;


namespace Category.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(o => o.Title)
                .NotEmpty().WithMessage(ValidationError.CreateCategory.Title_Is_Required)
                .MinimumLength(3).WithMessage(ValidationError.CreateCategory.Title_Length_Is_Not_Valid)
                .MaximumLength(50).WithMessage(ValidationError.CreateCategory.Title_Length_Is_Not_Valid);

            RuleFor(o => o.ShorDescription)
                .NotEmpty().WithMessage(ValidationError.CreateCategory.ShorDescription_Is_Required)
                .MinimumLength(15).WithMessage(ValidationError.CreateCategory.ShorDescription_Is_Cannot_Less_Length)
                .MaximumLength(155).WithMessage(ValidationError.CreateCategory.ShorDescription_Length_Is_Cannot_Greater_Than);
        }
    }
}

using Category.Application.Core.ApplicationError;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.UpdateCategory
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(o => o.Id)
                .NotEmpty().WithMessage(ValidationError.UpdateCategory.ID_Is_Required)
                .NotNull().WithMessage(ValidationError.UpdateCategory.ID_Is_Required);

            RuleFor(o => o.Title)
                .NotEmpty().WithMessage(ValidationError.UpdateCategory.Title_Is_Required)
                .MinimumLength(3).WithMessage(ValidationError.UpdateCategory.Title_Length_Is_Not_Valid)
                .MaximumLength(50).WithMessage(ValidationError.UpdateCategory.Title_Length_Is_Not_Valid);

            RuleFor(o => o.ShorDescription)
                .NotEmpty().WithMessage(ValidationError.UpdateCategory.ShorDescription_Is_Required)
                .MinimumLength(15).WithMessage(ValidationError.UpdateCategory.ShorDescription_Is_Cannot_Less_Length)
                .MaximumLength(155).WithMessage(ValidationError.UpdateCategory.ShorDescription_Length_Is_Cannot_Greater_Than);
        }
    }
}

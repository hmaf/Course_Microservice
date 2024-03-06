using Category.Application.Core.ApplicationError;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidation : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidation()
        {
            RuleFor(o => o.Id)
                .NotEmpty().WithMessage(ValidationError.DeleteCategory.ID_Is_Required)
                .NotNull().WithMessage(ValidationError.DeleteCategory.ID_Is_Required);
        }
    }
}

using Category.Api.Contracts;
using Category.Api.Exception;
using Category.Api.Infrastructure;
using Category.Application.Features.Commands.CreateCategory;
using Category.Application.Features.Commands.DeleteCategory;
using Category.Application.Features.Commands.UpdateCategory;
using Category.Application.Features.Queries.GetAllCategory;
using Category.Application.Features.Queries.GetCategoryById;
using Category.Application.Features.Queries.GetCategoryByTitile;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Category.Api.Controllers
{
    public sealed class CategoryController : ApiController
    {
        public CategoryController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet(ApiRoutes.Category.GetCategories)]
        public async Task<IActionResult> GetCategories([FromQuery]GetAllCategoryRequest query)
                => await _mediator.Send(query)
                        .Match(dinner => Ok(dinner),
                               errors => Problem(errors));

        [HttpGet(ApiRoutes.Category.GetCategoryById)]
        public async Task<IActionResult> GetCategoryById(string CategoryId)
                => await _mediator.Send(new GetCategoryByIdRequest(CategoryId))
                        .Match(dinner => Ok(dinner),
                               errors => Problem(errors));

        [HttpPost(ApiRoutes.Category.GetCategoryByTitle)]
        public async Task<IActionResult> GetCategoryByTitle(string Title)
                => await _mediator.Send(new GetCategoryByTitileRequest(Title))
                        .Match(dinner => Ok(dinner),
                               errors => Problem(errors));

        [HttpPost(ApiRoutes.Category.CreateCategory)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception.Result), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
                =>  await _mediator.Send(command).Match(
                        dinner => Ok(dinner),
                        errors => Problem(errors)); 

        [HttpPut(ApiRoutes.Category.UpdateCategory)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception.Result), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
                => await _mediator.Send(command).Match(
                            dinner => Ok(dinner),
                            errors => Problem(errors));

        [HttpDelete(ApiRoutes.Category.DeleteCategory)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Exception.Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(string CategoryId)
                => await _mediator.Send(new DeleteCategoryCommand(CategoryId)).Match(
                                dinner => NoContent(),
                                errors => Problem(errors));
    }
}

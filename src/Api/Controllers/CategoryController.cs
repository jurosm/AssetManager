using AssetManager.Application.Handlers.Categories.Commands.CreateCategory;
using AssetManager.Application.Handlers.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AssetManager.Api.Controllers
{
    [Route("category")]
    public class CategoryController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryCommand command)
        {
            return StatusCode((int)HttpStatusCode.Created, await mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList([FromQuery]GetCategoryListQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}

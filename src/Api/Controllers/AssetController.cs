using AssetManager.Application.Handlers.Assets.Command.CreateAsset;
using AssetManager.Application.Handlers.Assets.Queries.GetAssetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AssetManager.Api.Controllers
{
    [Route("asset")]
    public class AssetController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAssetList([FromQuery]GetAssetListQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsset([FromBody]CreateAssetCommand command)
        {
            return StatusCode((int)HttpStatusCode.Created, await mediator.Send(command));
        }
    }
}

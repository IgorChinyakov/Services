using Application.LocationsFeatures.Create;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
using Presentation.Responses;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateLocationRequest request,
            [FromServices] CreateLocationHandler handler,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateLocationCommand(
                request.Name,
                request.Address,
                request.TimeZone);
            var result = await handler.Handle(command, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Envelope.Ok(result.Value);
        }
    }
}

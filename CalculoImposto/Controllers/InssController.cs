using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InssController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {

        var command = new Application.UseCases.Inss.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);


        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);

    }
}

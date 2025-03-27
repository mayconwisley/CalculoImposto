using CalculoImposto.Application.Dtos.Irrf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IrrfController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] IrrfCreateDto irrfCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.Create.Command(irrfCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
}

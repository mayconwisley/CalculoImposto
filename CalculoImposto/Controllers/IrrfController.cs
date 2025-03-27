using CalculoImposto.Application.Dtos.Irrf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IrrfController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] IrrfCreateDto irrfCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.Create.Command(irrfCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] IrrfDto irrfDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(irrfDto.Id.ToString()))
        {
            return BadRequest("Id é requerido na entidade IRRF");
        }

        var command = new Application.UseCases.Irrf.Update.Command(irrfDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.Delete.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByCompetenceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Irrf.GetById.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }

}

using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DescontoMinimoController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] DescontoMinimoCreateDto descontoMinimoCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDescontoMinimo.Create.Command(descontoMinimoCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] DescontoMinimoDto descontoMinimoDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(descontoMinimoDto.Id.ToString()))
        {
            return BadRequest("Id é requerido na entidade Desconto Minimo");
        }

        var command = new Application.UseCases.IrrfDescontoMinimo.Update.Command(descontoMinimoDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDescontoMinimo.Delete.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDescontoMinimo.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDescontoMinimo.GetById.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("competence/{competence:datetime}")]
    public async Task<ActionResult> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDescontoMinimo.GetByCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
}

using CalculoImposto.Application.Dtos.IrrfDependente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DependenteController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] DependenteCreateDto dependenteCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDependente.Create.Command(dependenteCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] DependenteDto dependenteDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(dependenteDto.Id.ToString()))
        {
            return BadRequest("Id é requerido na entidade Dependente");
        }

        var command = new Application.UseCases.IrrfDependente.Update.Command(dependenteDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDependente.Delete.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDependente.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDependente.GetById.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("competence/{competence:datetime}")]
    public async Task<ActionResult> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfDependente.GetByCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
}

using CalculoImposto.Application.Dtos.IrrfSimplificado;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimplificadoController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] SimplificadoCreateDto simplificadoCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfSimplificado.Create.Command(simplificadoCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] SimplificadoDto simplificadoDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(simplificadoDto.Id.ToString()))
        {
            return BadRequest("Id é requerido na entidade Simplificado");
        }

        var command = new Application.UseCases.IrrfSimplificado.Update.Command(simplificadoDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfSimplificado.Delete.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfSimplificado.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfSimplificado.GetById.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
    [HttpGet("competence/{competence:datetime}")]
    public async Task<ActionResult> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.IrrfSimplificado.GetByCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
}

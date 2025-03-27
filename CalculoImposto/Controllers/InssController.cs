using CalculoImposto.Application.Dtos.Inss;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InssController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] InssCreateDto inssCreateDto, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.Create.Command(inssCreateDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] InssDto inssDto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(inssDto.Id.ToString()))
        {
            return BadRequest("Id é requerido na entidade INSS");
        }

        var command = new Application.UseCases.Inss.Update.Command(inssDto);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.Delete.Command(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int size = 25, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetAll.Command(page, size);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }

    [HttpGet("competence/{competence:datetime}")]
    public async Task<ActionResult> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetByCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }

    [HttpGet("rangeByCompetenceAndBaseInss/{competence:datetime}/{baseInss:decimal}")]
    public async Task<ActionResult> GetRangeByCompetenceAndBaseInssAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetRange.Command(competence, baseInss);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }

    [HttpGet("lastRangeByCompetence/{competence:datetime}")]
    public async Task<ActionResult> GetLastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetLastRangeCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }

    [HttpGet("percentRangeCompetence/{competence:datetime}/{range:int}")]
    public async Task<ActionResult> GetPercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetLastRangeCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }

    [HttpGet("valueRangeCompetence/{competence:datetime}/{range:int}")]
    public async Task<ActionResult> GetValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetValueRangeCompetence.Command(competence, range);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }

    [HttpGet("valueRoofCompetence/{competence:datetime}")]
    public async Task<ActionResult> GetValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetValueRoofCompetence.Command(competence);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ? Ok(result.Value) :
                                 BadRequest(result.Error);
    }



}

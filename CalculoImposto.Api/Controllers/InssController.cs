﻿using CalculoImposto.Application.Dtos.Inss;
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
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.GetById.Command(id);
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
}

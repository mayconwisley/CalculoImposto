using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculateController(ISender _sender) : ControllerBase
{
    [HttpGet("Inss/{competence:datetime}/{baseInss:decimal}")]
    public async Task<ActionResult> GetByIdAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default)
    {
        var command = new Application.UseCases.Inss.Calculate.Command(competence, baseInss);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSucess ?
            Ok(result.Value) :
            BadRequest(result.Error);
    }
}

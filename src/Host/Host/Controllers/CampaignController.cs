using Application.Messages.Dto;
using Application.Messages.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Messages.Command;
using Microsoft.AspNetCore.Authorization;

namespace Host.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class CampaignController(IMediator mediator) : ControllerBase //TODO Projeye �zel base olmal� , �ifreleme request response objeleri vs i�in.
{
    //TODO: Request ve Reponse objeleri base bir objeden t�remeli. O base objeler kullan�lmal�.

    [HttpGet]
    [ProducesResponseType(typeof(ActiveCampaignsResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Get()
    {
        var response = await mediator.Send(new ActiveCampaignsQuery());

        if (response.Count() < 1)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ActiveCampaignsResponseDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Create([FromBody] CreateCampaignRequestDto request)
    {
        var response = await mediator.Send(new CreateCampaignCommand(request));

        if (!response)  //TODO: Create edememe nedenleri d�n�lmeli ona g�re response wrap edilmeli ama case study oldu�u i�in detayland�rmad�m.
            return BadRequest();

        return StatusCode(201);
    }

    [HttpPut]  //TODO Patch kullan�labilir fakat patch kullan�m� zahmetli oldugu i�in �uan es ge�iyorum.
    [ProducesResponseType(typeof(ActiveCampaignsResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateCampaignRequestDto request, int campaignId)
    {
        var response = await mediator.Send(new UpdateCampaignCommand(request, campaignId));

        if (!response)  //TODO: update edememe nedenleri d�n�lmeli ona g�re response wrap edilmeli ama case study oldu�u i�in detayland�rmad�m.
            return BadRequest();

        return Ok();
    }
}
using Application.Members.Queries;
using Application.Models.Members.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] MembersRequest request)
    {
        var result = await _mediator.Send(new GetMembersQuery(request));

        return Ok(result);
    }

}



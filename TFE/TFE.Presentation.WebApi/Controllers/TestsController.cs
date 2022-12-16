using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFE.Application.CQRS.Test.Queries.GetAllTest;
using TFE.Domain.Entities;

namespace TFE.Presentation.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TestsController : ControllerBase
{
    private readonly ISender _sender;

    public TestsController(ISender sender)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }

    [HttpGet]
    public async Task<IEnumerable<Test>> GetAllTest(CancellationToken cancellationToken)
    {
        var query = new GetAllTestQuery();
        return await _sender.Send(query, cancellationToken);
    }
}
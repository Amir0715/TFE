﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFE.Application.CQRS.Tests.Commands.CreateTest;
using TFE.Application.CQRS.Tests.Queries.GetAllTest;
using TFE.Application.CQRS.Tests.Queries.GetTest;
using TFE.Domain.Entities;
using TFE.WebApi.DTOs;

namespace TFE.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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

    [HttpPost]
    public async Task<Test> CreateTest(CreateTestDTO newTest,CancellationToken cancellationToken)
    {
        var newTestId = await _sender.Send(new CreateTestCommand(newTest.Title, newTest.Description, newTest.CategoryId), cancellationToken);

        return await _sender.Send(new GetTestQuery(newTestId), cancellationToken);
    }
}
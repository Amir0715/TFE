using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFE.Application.CQRS.Categories.Commands.CreateCategory;
using TFE.Application.CQRS.Categories.Queries.GetAllCategory;
using TFE.Application.CQRS.Categories.Queries.GetCategory;
using TFE.Domain.Entities;
using TFE.WebApi.DTOs;

namespace TFE.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }

    [HttpPost]
    public async Task<Category> CreateCategory(CreateCategoryDTO newCategory, CancellationToken cancellationToken)
    {
        var newCategoryId = await _sender.Send(new CreateCategoryCommand(newCategory.Title, newCategory.Description, newCategory.ParentCategoryId), cancellationToken);
        return await _sender.Send(new GetCategoryQuery(newCategoryId), cancellationToken);
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
    {
        return await _sender.Send(new GetAllCategoryQuery(), cancellationToken);
    }
}
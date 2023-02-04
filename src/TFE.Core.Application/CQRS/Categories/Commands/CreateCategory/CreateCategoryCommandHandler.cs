using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;
using TFE.Infrastructure;

namespace TFE.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : BaseHandler, ICommandHandler<CreateCategoryCommand, int>
{
    public CreateCategoryCommandHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? parentCategory = null;
        if (request.ParentCategoryId.HasValue)
            parentCategory = await DbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.ParentCategoryId.Value, cancellationToken);

        var category = new Category(request.Title, request.Description, parentCategory);

        await DbContext.Categories.AddAsync(category, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
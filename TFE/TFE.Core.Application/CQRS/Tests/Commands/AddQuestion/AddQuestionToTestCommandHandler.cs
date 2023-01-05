using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;
using TFE.Infrastructure;
using TFE.Infrastructure.Exceptions.NotFoundExceptions;

namespace TFE.Application.CQRS.Tests.Commands.AddQuestion;

public class AddQuestionToTestCommandHandler : BaseHandler, ICommandHandler<AddQuestionToTestCommand, int>
{
    public AddQuestionToTestCommandHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<int> Handle(AddQuestionToTestCommand request, CancellationToken cancellationToken)
    {
        var test = await DbContext.Tests.FirstOrDefaultAsync(x => x.Id == request.TestId, cancellationToken);
        if (test == null)
        {
            throw new NotFoundException<Test>(request.TestId);
        }

        var question = test.AddQuestion(request.Title, request.Body, request.QuestionType);
        await DbContext.SaveChangesAsync(cancellationToken);
        return question.Id;
    }
}
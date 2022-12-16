using TFE.Application.CQRS.Abstractions.Messaging;

namespace TFE.Application.CQRS.Test.Queries.GetAllTest;

public sealed record GetAllTestQuery() 
    : IQuery<IEnumerable<Domain.Entities.Test>>;
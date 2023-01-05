using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;

namespace TFE.Application.CQRS.Tests.Queries.GetTest;

public record GetTestQuery(int TestId) : IQuery<Test>;
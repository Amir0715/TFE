using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Application.CQRS.Tests.Queries.GetTest;

public record GetTestQuery(int TestId) : IQuery<Test>;
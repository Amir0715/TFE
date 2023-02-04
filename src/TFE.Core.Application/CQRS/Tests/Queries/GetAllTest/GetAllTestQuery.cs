using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Application.CQRS.Tests.Queries.GetAllTest;

public sealed record GetAllTestQuery : IQuery<IEnumerable<Test>>;
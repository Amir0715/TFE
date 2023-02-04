using TFE.Domain.Abstractions;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Domain.Testing.AuthorAgregate;

/// <summary>
/// Пройденный тест
/// </summary>
public class PassedTest : Entity
{
    public int TestId { get; private set; }
    public DateTime CompletedDateTime { get; private set; }

    public int PassedUserId { get; private set; }
}
using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

/// <summary>
/// Пройденный тест
/// </summary>
public class PassedTest : Entity
{
    public int TestId { get; private set; }
    public Test Test { get; private set; }
    public DateTime CompletedDateTime { get; private set; }

    public int PassedUserId { get; private set; }
    public UserProfile PassedUser { get; private set; }
}
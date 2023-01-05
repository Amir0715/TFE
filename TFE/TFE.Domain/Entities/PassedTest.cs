using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

/// <summary>
/// Пройденный тест
/// </summary>
public class PassedTest : Entity
{
    // TODO: Добавить пользователя
    public Test Test { get; private set; }
    public DateTime CompletedDateTime { get; private set; }
}
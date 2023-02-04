using TFE.Domain.Abstractions;
using TFE.Domain.Testing.AuthorAgregate;

namespace TFE.Domain.Testing.TestAgregate;

/// <summary>
/// Вариант ответа на вопрос
/// </summary>
public class AnswerVariant : Entity
{
    public Question Question { get; private set; }
    public PassedTest PassedTest { get; private set; }
    public string Value { get; private set; }
    public bool IsCorrect { get; private set; }
}
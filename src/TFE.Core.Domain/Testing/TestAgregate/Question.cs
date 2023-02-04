using TFE.Domain.Abstractions;

namespace TFE.Domain.Testing.TestAgregate;

public class Question : Entity
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public QuestionType Type { get; private set; }
    public int TestId { get; private set; }
    public Test Test { get; private set; }

    private Question()
    {
    }

    public Question(string title, string body, QuestionType type)
    {
        if (string.IsNullOrEmpty(title)) throw new ArgumentException("Value cannot be null or empty.", nameof(title));
        if (string.IsNullOrEmpty(body)) throw new ArgumentException("Value cannot be null or empty.", nameof(body));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(body));

        Title = title;
        Body = body;
        Type = type;
    }
}
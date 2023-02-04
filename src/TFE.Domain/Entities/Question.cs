using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class Question : Entity
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public QuestionType QuestionType { get; private set; }
    public Test Test { get; private set; }
}
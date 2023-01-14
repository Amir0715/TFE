using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class Test : Entity
{
    private HashSet<Question> _questions;

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }

    public IReadOnlyCollection<Question> Questions => _questions;

    public int? AuthorProfileId { get; private set; }
    public UserProfile? AuthorProfile { get; private set; }

    private Test()
    {
        _questions = new HashSet<Question>();
    }

    public Test(string title, string description, Category category, UserProfile authorProfile) : this()
    {
        if (string.IsNullOrEmpty(title)) throw new ArgumentException("Value cannot be null or empty.", nameof(title));
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Value cannot be null or empty.", nameof(description));
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

        Title = title;
        Description = description;

        AuthorProfile = authorProfile ?? throw new ArgumentNullException(nameof(authorProfile));
        AuthorProfileId = authorProfile.Id;

        Category = category ?? throw new ArgumentNullException(nameof(category));
        CategoryId = category.Id;
    }

    public Question AddQuestion(string title, string body, QuestionType type)
    {
        var question = new Question(title, body, type);
        _questions.Add(question);

        return question;
    }
}
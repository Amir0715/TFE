using TFE.Domain.Abstractions;

namespace TFE.Domain.Testing.AuthorAgregate;

public class Author : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Patronymic { get; private set; }

    private List<PassedTest> _passedTests;
    public IReadOnlyCollection<PassedTest> PassedTests => _passedTests.AsReadOnly();

    private Author()
    {
        _passedTests = new List<PassedTest>();
    }

    public Author(string firstName, string lastName, string? patronymic = null)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("Value cannot be null or empty.", nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Value cannot be null or empty.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }
}
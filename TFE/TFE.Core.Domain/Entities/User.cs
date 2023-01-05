using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class User : Entity
{
    public string UserName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime? BirthDate { get; private set; }

    private User()
    {
    }

    public User(string userName, string firstName, string lastName, DateTime? birthDate)
    {
        if (string.IsNullOrEmpty(userName))
            throw new ArgumentException("Value cannot be null or empty.", nameof(userName));
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("Value cannot be null or empty.", nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Value cannot be null or empty.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(userName));
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(lastName));

        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
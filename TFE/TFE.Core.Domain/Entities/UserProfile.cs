using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class UserProfile : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Patronymic { get; private set; }
    public DateTime? BirthDate { get; private set; }

    private UserProfile()
    {
    }

    public UserProfile(string firstName, string lastName, string? patronymic = null, DateTime? birthDate = null)
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
        BirthDate = birthDate;
        Patronymic = patronymic;
    }
}
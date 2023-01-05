using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class Category : Entity
{
    private readonly HashSet<Category> _childCategories;
    private readonly HashSet<Test> _tests;

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
    public IReadOnlyCollection<Category> ChildCategories => _childCategories;
    public IReadOnlyCollection<Test> Tests => _tests;

    private Category()
    {
        _childCategories = new HashSet<Category>();
        _tests = new HashSet<Test>();
    }

    public Category(string name, string description, Category? parentCategory = null) : this()
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Value cannot be null or empty.", nameof(description));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

        Name = name;
        Description = description;
        ParentCategoryId = parentCategory?.Id;
    }

    public void AddChild(Category child)
    {
        if (child == null) throw new ArgumentNullException(nameof(child));
        if (child.Id == Id) throw new ArgumentException("Категория не может являться потомком для себя", nameof(child));
        if (_childCategories.Contains(child)) throw new ArgumentException("Категория уже является потомком", nameof(child));
        _childCategories.Add(child);
    }
}
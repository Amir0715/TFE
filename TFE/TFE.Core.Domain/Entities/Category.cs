using TFE.Domain.Abstractions;

namespace TFE.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category? ParentCategory { get; private set; }
}